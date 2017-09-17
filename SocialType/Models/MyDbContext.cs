using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SocialType.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyDbContext")
        {

        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkType> Types { get; set; }
        public DbSet<DrinkFeedback> Feedbacks { get; set; }
        public DbSet<Location> Locations { get; set; }


    }
}