namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUpload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrinkImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrinkId = c.Int(nullable: false),
                        ImageOfDrink = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DrinkImages");
        }
    }
}
