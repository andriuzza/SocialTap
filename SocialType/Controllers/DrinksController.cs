using Emgu.CV;
using Emgu.CV.Structure;
using OpenCvSharp;
using SocialType.Models;
using SocialType.Services;
using SocialType.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SocialType.Controllers
{

    [Authorize]
    public class DrinksController : Controller
    {
        // GET: Drinks
        private MyDbContext db = new MyDbContext();

        public ActionResult Index(string sortOrder, string searchString = null)
        {

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RateSortParm = sortOrder == "Rating" ? "rating_desc" : "Rating";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                ViewBag.SearchString = searchString;
            }
            if (ViewBag.SearchString != null)
            {
                searchString = ViewBag.SearchString;
            }
          

            SortingServices data = new SortingServices();
            IEnumerable<Drink> sortedEl = data.SortElementBy(sortOrder, searchString);
            return View(sortedEl);
        }

        public async Task<ActionResult> Post()
        {
            DrinkViewModel viewModel =  await GetViewModelOfDrinks();
            return View("SaveRecord", viewModel);
        }

        private async Task<DrinkViewModel> GetViewModelOfDrinks()
        {
            var TypesOfDrink = await GetTypes();
            var Locations = await GetLocations();
            var viewModel = new DrinkViewModel
            {
                Drink = new Drink(),
                TypesDrinks = TypesOfDrink,
                Locations = Locations
            };

           
            return viewModel;
        }

        public async Task<IEnumerable<DrinkType>> GetTypes()
        {
            return await Task.Factory.StartNew(()=> {
                return db.Types.ToList();
            });
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await Task.Factory.StartNew(()=> {
                return db.Locations.ToList();
            }); 
        }



        public ActionResult SaveRecord(DrinkViewModel vm)
        {
            if (vm.Drink.Name != null && vm.Drink.Price != 0)
            {
                Drink drink = new Drink();
                drink.Name = vm.Drink.Name;
                drink.Price = vm.Drink.Price;
                drink.DrinkTypeId = vm.TypeId;
                drink.LocationOfDrinkId = vm.LocationId;
                db.Drinks.Add(drink);

                db.SaveChanges();
                NotificationHandling handler = new NotificationHandling(drink);
                return RedirectToAction("Index");
            }
            return Content("Wrong input");
        }

      
        [HttpPost]
        public ActionResult Save(Drink drink, HttpPostedFileBase imageData)
        {
            if(imageData != null)
            {
                DrinkImage img = new DrinkImage();
                img.ImageOfDrink = new byte[imageData.ContentLength];
                img.DrinkId = drink.Id;
                imageData.InputStream.Read(img.ImageOfDrink, 0, imageData.ContentLength);
                db.Images.Add(img);
            }
            var item = db.Drinks.Single(m => m.Id == drink.Id);
            item.HowManyTimes++;
            item.Rating = (item.Rating + drink.Rating) / item.HowManyTimes;
            db.SaveChanges();

            using (var image = IplImage.FromStream(imageData.InputStream, LoadMode.Color))
            {

                using (var grayImage = new IplImage(image.Size, BitDepth.U8, 1))
                using (var cannyImage = new IplImage(image.Size, BitDepth.U8, 1))
                {
                    Cv.CvtColor(image, grayImage, ColorConversion.BgrToGray);
                    Cv.Canny(grayImage, cannyImage, 60, 180);
                    Bitmap a = new Bitmap(imageData.InputStream);
                    Image<Bgr, Byte> b = new Image<Bgr, byte>(a);

                    var img = IplImage.FromStream(imageData.InputStream, LoadMode.Color);
                    var img2 = IplImage.FromStream(imageData.InputStream, LoadMode.Color);
                    int[,] arr = new int[cannyImage.Height, cannyImage.Width];

                    for (int i = 0; i < cannyImage.Height; i++)
                    {
                        for (int j = 0; j < cannyImage.Width; j++)
                        {
                            if (cannyImage[i, j] > 0)
                            {
                                arr[i, j] = 1;
                            }
                        }
                    }

                    for (int i = 0; i < img.Height - 1; i++)
                    {
                        for (int j = 0; j < img.Width - 1; j++)
                        {
                            if (arr[i, j] == 1)
                            {
                                img[i, j] = CvColor.DeepPink;
                            }
                        }
                    }

                    int BottleX1 = 0, BottleY1 = 0;
                    int BottleX2 = 0, BottleY2 = 0;

                    int x3 = 0, y3 = 0;

                    int x4 = 0, y4 = 0;

                    int MarkedAsFirst = 0;
                    int[,] ImagePixels = new int[img.Height, img.Width];

                    for (int i = 0; i < img.Height / 2; i++)
                    {
                        for (int j = 0; j < img.Width / 2; j++)
                        {
                            if (arr[i, j] == 1 && MarkedAsFirst == 0)
                            {
                                BottleX1 = j;
                                BottleY1 = i;
                                MarkedAsFirst = 1;
                            }
                            if (arr[i, j] == 1)
                            {
                                ImagePixels[i, j] = 1;
                                break;
                            }
                        }
                    }

                    MarkedAsFirst = 0;
                    for (int i = 0; i < img.Height / 2; i++)
                    {
                        for (int j = img.Width - 1; j > img.Width / 2; j--)
                        {
                            if (arr[i, j] == 1 && MarkedAsFirst == 0)
                            {
                                BottleX2 = j;
                                BottleY2 = i;
                                MarkedAsFirst = 1;
                            }
                            if (arr[i, j] == 1)
                            {
                                ImagePixels[i, j] = 1;
                                break;
                            }
                        }

                    }

                    MarkedAsFirst = 0;
                    for (int i = img.Height - 1; i > img.Height / 2; i--)
                    {
                        for (int j = 0; j < img.Width / 2; j++)
                        {
                            if (arr[i, j] == 1 && MarkedAsFirst == 0)
                            {
                                x3 = j;
                                y3 = i;
                                MarkedAsFirst = 1;
                            }
                            if (arr[i, j] == 1)
                            {
                                ImagePixels[i, j] = 1;
                                break;
                            }

                        }

                    }

                    MarkedAsFirst = 0;
                    for (int i = img.Height - 1; i > img.Height / 2; i--)
                    {
                        for (int j = img.Width - 1; j > img.Width / 2; j--)
                        {
                            if (arr[i, j] == 1 && MarkedAsFirst == 0)
                            {
                                x4 = j;
                                y4 = i;
                                MarkedAsFirst = 1;
                            }
                            if (arr[i, j] == 1)
                            {
                                ImagePixels[i, j] = 1;
                                break;
                            }
                        }
                    }


                    int HeightDifference = (BottleY2 + BottleY1) / 2;
                    int WidthDifference = (BottleX1 + BottleX2) / 2;
                 /*   for (int i = BottleX1; i < BottleX2; i++)
                    {
                        ImagePixels[HeightDifference, i] = 1;
                        img[HeightDifference, i] = CvColor.DarkBlue;
                    }*/

                    for (int i = 0; i < img.Height - 1; i++)
                    {
                        for (int j = 0; j < img.Width - 1; j++)
                        {
                            if (ImagePixels[i, j] == 1)
                            {
                                img2[i, j] = CvColor.DarkBlue;
                            }
                        }
                    }

                    byte[] depthPixelData = new byte[1000 * 1000]; // your data
                    Image<Bgr, byte> depthImage = new Image<Bgr, byte>(img.Height, img.Width);

                    int BottlePixels = 0;
                    int NoLiquidPixels = 0;
                    int MarkedAsLiquidStart = 0;
                    int Height = 0;

                    for (int i = HeightDifference; i < a.Height; i++)
                    {
                        for (int j = 0; j < a.Width; j++)
                        {
                            if (ImagePixels[i, j] == 1)
                            {
                                BottlePixels++;
                                j++;
                                while (ImagePixels[i, j] == 0)
                                {
                                    if (j == img2.Width - 1) { break; }
                                    Color clr = a.GetPixel(j, i);
                                    BottlePixels++;
                                    if (clr.B < 50 && MarkedAsLiquidStart == 0)
                                    {
                                        NoLiquidPixels = BottlePixels;
                                        MarkedAsLiquidStart = 1;
                                        Height = i;
                                        for (int z = BottleX1; z < BottleX2; z++)
                                        {
                                            img2[Height, z] = CvColor.DarkSlateBlue;
                                        }
                                    }
                                    j++;
                                }
                                break;
                            }

                        }
                    }

                    double LiquidRatio1 = ((BottlePixels *1.0 - NoLiquidPixels) / BottlePixels) * 100;
                    double LiquidRatio = Math.Round(LiquidRatio1, 2);
                    byte[] cannyBytes = img.ToBytes(".png");
                    string base64 = Convert.ToBase64String(cannyBytes); /*convert image to string in base 64 encoding */

                    ViewBag.Ratio = LiquidRatio;
                    ViewBag.Image = base64;
                }
            }

            return View("ResultOfDetection");
        }

        public ActionResult Edit(int? Id)
        {
            var drink = db.Drinks.SingleOrDefault(m => m.Id == Id);

            ViewBag.NoImages = "";

            if (drink == null)
            {
                return HttpNotFound();
            }
            var imagesOfDrinks = db.Images.Where(m => m.DrinkId == Id).ToList();
            int skaicius = drink.Name.WordCount();
            if(imagesOfDrinks == null)
            {
                ViewBag.NoImages = "No images found of any drink";
                return View(drink);
            }
          
            string[] base64 = new string[imagesOfDrinks.Count];
            int i = 0;
            foreach(var a in imagesOfDrinks)
            {
                base64[i] = Convert.ToBase64String(a.ImageOfDrink);
                i++;
            }
            ViewBag.Array = base64;
            return View(drink);
        }
    }
}