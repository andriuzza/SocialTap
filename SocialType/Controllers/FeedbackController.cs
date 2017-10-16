using SocialType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialType.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        private MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search()
        {
            
            return View();
        }


    }
}