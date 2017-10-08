using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;
namespace SocialType.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyDbContext")
        {

        }

        public DbSet<Drink> drinks { get; set; }
        public DbSet<DrinkType> Types { get; set; }
        public DbSet<DrinkFeedback> Feedbacks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<DrinkImage> Images { get; set; }
       

    }
}