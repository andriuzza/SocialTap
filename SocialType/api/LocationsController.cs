using SocialType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialType.api
{
    
    public class LocationsController : ApiController
    {
        private MyDbContext db;
        public LocationsController()
        {
            db = new MyDbContext();
        }
        public IEnumerable<Location> GetLocation()
        {
            return db.Locations.ToList();
        }
        [HttpPost]
        public Location Post(Location location)
        {
            Location loc = new Location();
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
            }
            return location;
        }
    }

   
}
