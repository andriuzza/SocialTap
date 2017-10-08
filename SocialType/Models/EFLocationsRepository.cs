﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.Models
{
    public class EFLocationsRepository: IRepository<Location>
    {
        MyDbContext db = new MyDbContext();
        public IQueryable<Location> GetAll()
        {
            return db.Locations; 
        }
    }
}