namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drinks", "DrinkType_Id1", "dbo.DrinkTypes");
            DropIndex("dbo.Drinks", new[] { "DrinkType_Id1" });
            RenameColumn(table: "dbo.Drinks", name: "DrinkType_Id1", newName: "DrinkTypeId");
            AlterColumn("dbo.Drinks", "DrinkTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Drinks", "DrinkTypeId");
            AddForeignKey("dbo.Drinks", "DrinkTypeId", "dbo.DrinkTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Drinks", "DrinkType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drinks", "DrinkType_Id", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Drinks", "DrinkTypeId", "dbo.DrinkTypes");
            DropIndex("dbo.Drinks", new[] { "DrinkTypeId" });
            AlterColumn("dbo.Drinks", "DrinkTypeId", c => c.Int());
            RenameColumn(table: "dbo.Drinks", name: "DrinkTypeId", newName: "DrinkType_Id1");
            CreateIndex("dbo.Drinks", "DrinkType_Id1");
            AddForeignKey("dbo.Drinks", "DrinkType_Id1", "dbo.DrinkTypes", "Id");
        }
    }
}
