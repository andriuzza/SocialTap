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
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationUser> NotificationUsers { get; set; }
        public DbSet<UserActivation> Activations { get; set; }
        public DbSet<LocationFeedback> LocationFeedbacks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>()
               .HasRequired(u => u.LocationOfDrink)
               .WithMany(e => e.Drinks)
               .HasForeignKey(a => a.LocationOfDrinkId)
               .WillCascadeOnDelete(true);


            modelBuilder.Entity<NotificationUser>()
                .HasRequired(a => a.UserAccount)
                .WithMany(b=>b.Notifications)
                .WillCascadeOnDelete(false);


        }
    }

   
}