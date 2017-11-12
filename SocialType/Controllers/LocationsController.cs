using SocialType.Models;
using SocialType.Repositories;
using SocialType.ViewModels;
using SocialType.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SocialType.Controllers
{
    public class LocationsController : Controller
    {
        private MyDbContext db = new MyDbContext();
        /*Dependecy injection */
        private IRepository<Location> repository;

        public LocationsController(IRepository<Location> _repository)
        {
            repository = _repository;
        }
        // GET: Locations
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Location model)
        {
            Location filterModel = db.Locations.Where(m => m.Name == model.Name).FirstOrDefault();
            try
            {
                if (filterModel == null)
                {
                    throw new BarNotFoundException("Couldnt find bar with this name");
                }
            }
            catch 
            {
               
            }
            return View(filterModel);
        }
        public ActionResult Show(int? Id)
        {
            var location = db.Locations.Where(m => m.Id == Id).FirstOrDefault();
            var vm = new LocationViewModel
            {
                Loc = location,
                Drinks = db.Drinks.Where(m => m.LocationOfDrinkId == location.Id).ToList(),


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

        public ViewResult ShowBars() /*a sub class of actionresult */
        {
            IEnumerable<Location> loc = repository.GetAll().ToList();
            return View(loc);
        }
    }
}