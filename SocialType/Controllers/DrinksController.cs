using SocialType.Models;
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


            var drinks = from s in db.drinks
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                drinks = drinks.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "rating_desc":
                    drinks = drinks.OrderByDescending(s => s.Rating);
                    break;
                case "Price":
                    drinks = drinks.OrderBy(s => s.Price);
                    break;
                case "name_desc":
                    drinks = drinks.OrderByDescending(s => s.Name);
                    break; /*nebutina sito case rasyti, nes niekada nebus name_desc, nes bus null, 
                    o jei null tai - DEFAULT*/

                default:
                    drinks = drinks.OrderBy(s => s.Name);
                    break;


            }

            /* Isveda visa sarasa gerimu*/
            IEnumerable<Drink> data = drinks.ToList();
            return View(data);
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
        public ActionResult Save(Drink drink)
        {
            var item = db.drinks.Single(m => m.Id == drink.Id);
            item.HowManyTimes++;
            item.Rating = (item.Rating + drink.Rating) / item.HowManyTimes;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? Id)
        {
            var drink = db.drinks.SingleOrDefault(m => m.Id == Id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }
    }
}