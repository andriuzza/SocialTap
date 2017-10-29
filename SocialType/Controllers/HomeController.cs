using Emgu.CV;
using Emgu.CV.Structure;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Web;
using System.Web.Mvc;

namespace SocialType.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Canny(HttpPostedFileBase imageData)
        {
            using (var image = IplImage.FromStream(imageData.InputStream, LoadMode.Color))
            {

                Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(1000, 1000);
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
                            if (arr[i,j] == 1)
                            {
                                img[i, j] = CvColor.DeepPink;
                            }
                        }
                    }

                    int x1 = 0, y1 = 0;

                    int x2 = 0, y2 = 0;

                    int x3 = 0, y3 = 0;

                    int x4 = 0, y4 = 0;

                    int yra = 0;
                    int[,] taskai = new int[4, 4];

                    int[,] visiTaskai = new int[img.Height, img.Width];

                    for (int i = 0; i < img.Height/2; i++)
                    {
                        for (int j = 0; j < img.Width/2; j++)
                        {
                            if (arr[i, j] == 1 && yra == 0)
                            {
                                x1 = j;
                                y1 = i;
                                yra = 1;
                            }
                            if (arr[i, j] == 1)
                            {
                                visiTaskai[i, j] = 1;
                                break;
                            }
                        }
                    }

                   yra = 0;
                   for (int i = 0; i < img.Height/2; i++)
                    {
                        for (int j = img.Width-1; j > img.Width/2; j--)
                        {
                            if (arr[i, j] == 1 && yra == 0)
                            {
                                x2 = j;
                                y2 = i;
                                yra = 1;
                            }
                            if (arr[i, j] == 1)
                            {
                                visiTaskai[i, j] = 1;
                                break;
                            }
                        }
                        
                    }

                    yra = 0;
                    for (int i = img.Height - 1; i > img.Height / 2; i--)
                    {
                        for (int j = 0 ; j < img.Width/2; j++)
                        { 
                            if (arr[i, j] == 1 && yra == 0)
                            {
                                x3 = j;
                                y3 = i;
                                yra = 1;
                            }
                            if (arr[i, j] == 1)
                            {
                                visiTaskai[i, j] = 1;
                                break;
                            }

                        }
                        
                    }

                    yra = 0;
                    for (int i = img.Height - 1; i > img.Height / 2; i--)
                    {
                        for (int j = img.Width - 1; j > img.Width/2; j--)
                        {
                            if (arr[i, j] == 1 && yra == 0)
                            {
                                x4 = j;
                                y4 = i;
                                yra = 1;
                            }
                            if (arr[i, j] == 1)
                            {
                                visiTaskai[i, j] = 1;
                                break;
                            }
                        }
                    }


                    int aukscioSkirtumas = (y2 + y1) / 2;
                    int plocioSkirtumas = (x1 + x2) / 2;
                    for (int i = x1; i < x2; i++)
                    {
                        visiTaskai[aukscioSkirtumas, i] = 1;
                        img[aukscioSkirtumas, i] = CvColor.DarkBlue;
                    }

                    for (int i = 0; i < img.Height - 1; i++)
                    {
                        for (int j = 0; j < img.Width - 1; j++)
                        {
                            if (visiTaskai[i, j] == 1)
                            {
                                img2[i, j] = CvColor.DarkBlue;
                            }
                        }
                    }
      
                    byte[] depthPixelData = new byte[1000 * 1000]; // your data


                    Image<Bgr, byte> depthImage = new Image<Bgr, byte>(img.Height, img.Width);

                    int count = 0;
                    int neipilta = 0;
                    int viskas = 0;
                    int aukstis = 0;
      
                    for (int i = aukscioSkirtumas; i < a.Height; i++)
                    {
                        for (int j = 0; j < a.Width; j++)
                        {
                           if(visiTaskai[i, j] == 1)
                            { count++;
                                j++;
                                while(visiTaskai[i, j] == 0)
                                {
                                    if(j == img2.Width - 1) { break; }
                                    Color clr = a.GetPixel(j, i);
                                    count++;
                                    if (clr.B < 50 && viskas == 0)
                                    {
                                        neipilta = count;
                                        viskas = 1;
                                        aukstis = i;
                                        for (int z = x1; z < x2; z++)
                                        {
                                            img2[aukstis, z] = CvColor.DarkSlateBlue;
                                        }

                                    }
                                    // img2[i, j] = CvColor.Tomato;
                                    j++;
                                }
                                break;
                            }
                            
                        }
                    }

                    double kiekIpilta = (neipilta / count) * 100;
                    Console.WriteLine(kiekIpilta);

                    Emgu.CV.Structure.MIplImage EE = b.MIplImage;
                    byte[] cannyBytes = img2.ToBytes(".png");
                    string base64 = Convert.ToBase64String(cannyBytes);

                    ViewBag.Suma = kiekIpilta;
                    ViewBag.Base64Image = base64;
                    }
                }

                return View();
        }
    }
}
 
                            