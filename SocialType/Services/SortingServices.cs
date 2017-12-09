using SocialType.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialType.Services
{

    // TODO kimutis : services? 
    public class SortingServices
    {
        // TODO kimutis : database should be in using or disposed
        private MyDbContext db = new MyDbContext();
        
        public IEnumerable<Drink> SortElementBy(string sortOrder, string searchString)
        {
            var drinks = from s in db.Drinks /*Linq selecting statemant */
                         select s;            

            if (!String.IsNullOrEmpty(searchString))
            {
                // TODO kimutis : is it sorting or searching method?
                drinks = drinks.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                // TODO kimutis : this should be refactored to enum
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