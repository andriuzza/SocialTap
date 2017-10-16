using System.Data.Entity;

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
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<DrinkImage> Images { get; set; }
       

    }
}