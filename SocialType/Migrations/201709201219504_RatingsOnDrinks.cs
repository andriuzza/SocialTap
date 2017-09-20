namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingsOnDrinks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drinks", "Rating", c => c.Double(nullable: false));
            AddColumn("dbo.Drinks", "HowManyTimes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drinks", "HowManyTimes");
            DropColumn("dbo.Drinks", "Rating");
        }
    }
}
