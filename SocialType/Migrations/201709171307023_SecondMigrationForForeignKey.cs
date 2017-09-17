namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigrationForForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drinks", "DrinkTypeId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drinks", "DrinkTypeId");
        }
    }
}
