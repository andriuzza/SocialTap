using SocialType.Models;
using SocialType.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialType.Controllers
{
    public class DrinksController : Controller
    {
        // GET: Drinks
        private MyDbContext db = new MyDbContext();

        public ActionResult Index()/* ISVEDA*/
        {
            /* Isveda visa sarasa gerimu*/
            IEnumerable<Drink> data = db.Drinks.ToList();
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
                db.Drinks.Add(drink);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Content("Wrong input");
        }
    }
}