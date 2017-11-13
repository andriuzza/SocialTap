namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationFeedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocationFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        DateFeedback = c.DateTime(nullable: false),
                        TextFeedback = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserID, cascadeDelete: true)
                .Index(t => t.LocationID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocationFeedbacks", "UserID", "dbo.UserAccounts");
            DropForeignKey("dbo.LocationFeedbacks", "LocationID", "dbo.Locations");
            DropIndex("dbo.LocationFeedbacks", new[] { "UserID" });
            DropIndex("dbo.LocationFeedbacks", new[] { "LocationID" });
            DropTable("dbo.LocationFeedbacks");
        }
    }
}
