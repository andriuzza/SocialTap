namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drinks", "Location", c => c.String());
            AddColumn("dbo.DrinkFeedbacks", "Location", c => c.String());
            AddColumn("dbo.DrinkFeedbacks", "LocationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DrinkFeedbacks", "LocationId");
            DropColumn("dbo.DrinkFeedbacks", "Location");
            DropColumn("dbo.Drinks", "Location");
        }
    }
}
