using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.Models
{
    public interface IRepository<T> where T: class /*where T means what constraint
        we will apply on, at this example we see it will be the class only waiting in this interface*/
    {
        IQueryable<T> GetAll();
    }
}