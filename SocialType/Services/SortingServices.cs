using SocialType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace SocialType.Services
{
    
    
    public class SortingServices
    {
        private MyDbContext db = new MyDbContext();
        
        public IEnumerable<Drink> SortElementBy(string sortOrder, string searchString)
        {
            var drinks = from s in db.drinks /*Linq selecting statemant */
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
                    break; 

                default:
                    drinks = drinks.OrderBy(s => s.Name);
                    break;


            }

            return drinks.ToList();
        }
    }
    
}