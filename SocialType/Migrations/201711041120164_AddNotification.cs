namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotificationUsers",
                c => new
                    {
                        UserAccountUserID = c.Int(nullable: false),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserAccountUserID, t.NotificationId })
                .ForeignKey("dbo.Notifications", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountUserID)
                .Index(t => t.UserAccountUserID)
                .Index(t => t.NotificationId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Drink_Id = c.Int(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.Drink_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Drink_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificationUsers", "UserAccountUserID", "dbo.UserAccounts");
            DropForeignKey("dbo.NotificationUsers", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Notifications", "Drink_Id", "dbo.Drinks");
            DropIndex("dbo.Notifications", new[] { "Location_Id" });
            DropIndex("dbo.Notifications", new[] { "Drink_Id" });
            DropIndex("dbo.NotificationUsers", new[] { "NotificationId" });
            DropIndex("dbo.NotificationUsers", new[] { "UserAccountUserID" });
            DropTable("dbo.Notifications");
            DropTable("dbo.NotificationUsers");
        }
    }
}
