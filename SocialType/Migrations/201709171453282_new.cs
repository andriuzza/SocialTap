namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drinks", "DrinkType_Id", "dbo.DrinkTypes");
            DropIndex("dbo.Drinks", new[] { "DrinkType_Id" });
            AddColumn("dbo.Drinks", "DrinkType_Id1", c => c.Int());
            AlterColumn("dbo.Drinks", "DrinkType_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Drinks", "DrinkType_Id1");
            AddForeignKey("dbo.Drinks", "DrinkType_Id1", "dbo.DrinkTypes", "Id");
            DropColumn("dbo.Drinks", "DrinkTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drinks", "DrinkTypeId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Drinks", "DrinkType_Id1", "dbo.DrinkTypes");
            DropIndex("dbo.Drinks", new[] { "DrinkType_Id1" });
            AlterColumn("dbo.Drinks", "DrinkType_Id", c => c.Int());
            DropColumn("dbo.Drinks", "DrinkType_Id1");
            CreateIndex("dbo.Drinks", "DrinkType_Id");
            AddForeignKey("dbo.Drinks", "DrinkType_Id", "dbo.DrinkTypes", "Id");
        }
    }
}
