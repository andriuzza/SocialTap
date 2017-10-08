using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.Models
{
    public class EFLocationsRepository: ILocationRepository
    {
        MyDbContext db = new MyDbContext();
        public IQueryable<Location> Locations()
        {
            return db.Locations; 
        }
    }
}