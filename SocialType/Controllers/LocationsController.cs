using SocialType.Models;
using SocialType.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialType.Controllers
{
    public class LocationsController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Locations
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Location model)
        {
            Location filterModel = db.Locations.Where(m => m.Name == model.Name).FirstOrDefault();
            return View(filterModel);
        }
        public ActionResult Show(int? Id)
        {
            var location = db.Locations.Where(m => m.Id == Id).FirstOrDefault();
            var vm = new LocationViewModel
            {
                loc = location,
                drinks = db.drinks.Where(m => m.Location == location.Name).ToList(),

                
            };
            return View(vm);
        }
        public ActionResult PostNewBar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostNewBar(LocationViewModel vm)
        {
            ViewBag.correct = "";
            Location loc = new Location();
            if (ModelState.IsValid)
            {
                loc.Name = vm.Name;
                loc.Latitude = vm.Latitude;
                loc.Longitude = vm.Longitude;
                loc.Address = vm.Address;
                
                db.Locations.Add(loc);
                db.SaveChanges();
                ViewBag.correct = "Succeed";
                
            }
            else
            {
                ViewBag.correct = "Failed";
            }
            return View();
        }
    }
}