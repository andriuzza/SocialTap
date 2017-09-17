namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        DrinkType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DrinkTypes", t => t.DrinkType_Id)
                .Index(t => t.DrinkType_Id);
            
            CreateTable(
                "dbo.DrinkTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DrinkFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Drink_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.Drink_Id)
                .Index(t => t.Drink_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrinkFeedbacks", "Drink_Id", "dbo.Drinks");
            DropForeignKey("dbo.Drinks", "DrinkType_Id", "dbo.DrinkTypes");
            DropIndex("dbo.DrinkFeedbacks", new[] { "Drink_Id" });
            DropIndex("dbo.Drinks", new[] { "DrinkType_Id" });
            DropTable("dbo.Locations");
            DropTable("dbo.DrinkFeedbacks");
            DropTable("dbo.DrinkTypes");
            DropTable("dbo.Drinks");
        }
    }
}
