using OpenCvSharp;
using System;
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
               
                using (var grayImage = new IplImage(image.Size, BitDepth.U8, 1))
                using (var cannyImage = new IplImage(image.Size, BitDepth.U8, 1))
                {
                    Cv.CvtColor(image, grayImage, ColorConversion.BgrToGray);
                    Cv.Canny(grayImage, cannyImage, 60, 180);

                    byte[] cannyBytes = cannyImage.ToBytes(".png");
                    string base64 = Convert.ToBase64String(cannyBytes);
                
                    ViewBag.Base64Image = base64;
                }
            }


            return View();
        }
    }
}