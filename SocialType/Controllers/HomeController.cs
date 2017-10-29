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
          

                return View();
        }
    }
}
 
                            