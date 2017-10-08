using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.Models
{
    public interface ILocationRepository
    {
        IQueryable<Location> Locations();
    }
}