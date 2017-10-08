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



            return drinks.ToList();
        }
    }
    
}