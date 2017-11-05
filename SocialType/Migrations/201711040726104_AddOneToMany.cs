namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneToMany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drinks", "LocationOfDrinkId", c => c.Int(nullable: false));
            CreateIndex("dbo.Drinks", "LocationOfDrinkId");
            AddForeignKey("dbo.Drinks", "LocationOfDrinkId", "dbo.Locations", "Id", cascadeDelete: true);
            DropColumn("dbo.Drinks", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drinks", "Location", c => c.String());
            DropForeignKey("dbo.Drinks", "LocationOfDrinkId", "dbo.Locations");
            DropIndex("dbo.Drinks", new[] { "LocationOfDrinkId" });
            DropColumn("dbo.Drinks", "LocationOfDrinkId");
        }
    }
}
