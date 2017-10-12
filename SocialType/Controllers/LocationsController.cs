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
        /*Dependecy injection */
        private IRepository<Location> repository;

      public  LocationsController(IRepository<Location> _repository)
        {
            repository = _repository;
        }
        // GET: Locations
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult View(int? Id)
        {
            var feedbackTemporary = db.LocationFeedback.Where(m => m.LocationID == Id).FirstOrDefault();
            var vm = new FeedbackViewModel
            {
                feedback = feedbackTemporary,
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(Location model)
        {
            ViewBag.Naujas = "";
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
        [Authorize]
        public ActionResult PostNewBar()
        {
            return View();
        }
        [Authorize]
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

        public ViewResult ShowBars() /*sub clas of actionresult */
        {
            IEnumerable<Location> loc = repository.GetAll().ToList();
            return View(loc);
        }
    }
}