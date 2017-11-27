﻿using SocialType.Models;
using System.Linq;

namespace SocialType.Repositories
{
    // TODO kimutis : ?
    public class EFDrinksRepository: IRepository<Drink>
    {
        MyDbContext db = new MyDbContext();
        /*IQueryable works on client side */
        public IQueryable<Drink> GetAll()
        {
            return db.Drinks;
        }
    }
}