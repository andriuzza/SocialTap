using SocialType.Models;
using SocialType.Services;
using SocialType.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialType.Controllers
{

    [Authorize]
    public class DrinksController : Controller
    {
        // GET: Drinks
        private MyDbContext db = new MyDbContext();

        public ActionResult Index(string sortOrder, string searchString)/* ISVEDA*/
        {

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RateSortParm = sortOrder == "Rating" ? "rating_desc" : "Rating";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            SortingServices data = new SortingServices();
            IEnumerable<Drink> sortedEl = data.SortElementBy(sortOrder, searchString);
            return View(sortedEl);
        }

        public ActionResult Post()
        {
            var type = db.Types.ToList();
            var viewModel = new DrinkViewModel
            {
                Drink = new Drink(),
                TypesDrinks = type
            };
            return View("SaveRecord",viewModel);
        }

        public ActionResult SaveRecord(DrinkViewModel vm)
        {
            if (vm.Drink.Name != null && vm.Drink.Price != 0)
            {
                Drink drink = new Drink();
                drink.Name = vm.Drink.Name;
                drink.Price = vm.Drink.Price;
                drink.DrinkTypeId = vm.Drink.DrinkTypeId;
                db.drinks.Add(drink);

                db.SaveChanges();
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
            var item = db.drinks.Single(m => m.Id == drink.Id);
            item.HowManyTimes++;
            item.Rating = (item.Rating + drink.Rating) / item.HowManyTimes;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? Id)
        {
            var drink = db.drinks.SingleOrDefault(m => m.Id == Id);

            ViewBag.NoImages = "";

            if (drink == null)
            {
                return HttpNotFound();
            }
            var imagesOfDrinks = db.Images.Where(m => m.DrinkId == Id).ToList();
            if(imagesOfDrinks == null)
            {
                ViewBag.NoImages = "No images found of the drink";
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