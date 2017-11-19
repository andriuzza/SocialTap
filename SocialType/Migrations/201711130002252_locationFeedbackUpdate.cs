namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationFeedbackUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LocationFeedbacks", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.LocationFeedbacks", "UserID", "dbo.UserAccounts");
            DropIndex("dbo.LocationFeedbacks", new[] { "LocationID" });
            DropIndex("dbo.LocationFeedbacks", new[] { "UserID" });
            AddColumn("dbo.LocationFeedbacks", "Feedback", c => c.String());
            AddColumn("dbo.LocationFeedbacks", "User", c => c.String());
            DropColumn("dbo.LocationFeedbacks", "UserID");
            DropColumn("dbo.LocationFeedbacks", "Rating");
            DropColumn("dbo.LocationFeedbacks", "DateFeedback");
            DropColumn("dbo.LocationFeedbacks", "TextFeedback");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocationFeedbacks", "TextFeedback", c => c.String());
            AddColumn("dbo.LocationFeedbacks", "DateFeedback", c => c.DateTime(nullable: false));
            AddColumn("dbo.LocationFeedbacks", "Rating", c => c.Double(nullable: false));
            AddColumn("dbo.LocationFeedbacks", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.LocationFeedbacks", "User");
            DropColumn("dbo.LocationFeedbacks", "Feedback");
            CreateIndex("dbo.LocationFeedbacks", "UserID");
            CreateIndex("dbo.LocationFeedbacks", "LocationID");
            AddForeignKey("dbo.LocationFeedbacks", "UserID", "dbo.UserAccounts", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.LocationFeedbacks", "LocationID", "dbo.Locations", "Id", cascadeDelete: true);
        }
    }
}
