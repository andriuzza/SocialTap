using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.Models
{
    public class EFDrinksRepository: IRepository<Drink>
    {
        MyDbContext db = new MyDbContext();
        /*IQueryable works on client side */
        public IQueryable<Drink> GetAll()
        {
            return db.drinks;
        }
    }
}