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
        // TODO kimutis : either dispose or use with using
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
            // TODO kimutis : you can move the filtering to first or default
            Location filterModel = db.Locations.Where(m => m.Name == model.Name).FirstOrDefault();
            try
            {
                // TODO kimutis : maybe we can use First() instead of first and default and just catch exception?
                if (filterModel == null)
                {
                    throw new BarNotFoundException("Couldnt find bar with this name");
                }
            }
            catch 
            {
                // TODO kimutis : ?
            }
            return View(filterModel);
        }
        // TODO kimutis : naming convention Id -> id
        public ActionResult Show(int? Id)
        {
            // TODO kimutis : what if Id will be null?
            // TODO kimutis : you can move the filtering to first or default
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
                // TODO kimutis : should be moved to database service
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

        // TODO kimutis : ?
        //~~~~~



        // TODO kimutis : spacing
        [HttpGet]
        public ActionResult PostFeedback(int id)
        {
            ViewBag.id = id;
            return View();

        }

        // TODO kimutis : spacing
        [HttpPost]
        public ActionResult PostFeedback(LocationFeedback locationFeedback)
        {

            if (ModelState.IsValid)
            {

                db.LocationFeedbacks.Add(locationFeedback);
                db.SaveChanges();
                return RedirectToAction("feedback", new { id = locationFeedback.LocationId });
            }


            return View(locationFeedback);
        }

        // TODO kimutis : Id -> id
        // TODO kimutis : Feedback what?
        public ActionResult Feedback(int Id = 1)
        {

            var location = db.Locations.Where(m => m.Id == Id).FirstOrDefault();
           
            var tempFeedbacks = db.LocationFeedbacks.Where(m => m.LocationId == location.Id).ToList();

            tempFeedbacks.Sort(delegate (LocationFeedback x, LocationFeedback y)
            {
                return x.Feedback.CompareTo(y.Feedback);
            });

            var vm = new LocationFeedbackViewModel
            {
                Location = location,
                LocationFeedbacks = tempFeedbacks
                
            };
            
            
            return View(vm);
        }
        
    }
}