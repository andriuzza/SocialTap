namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locFeedbackFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LocationFeedbacks", "DrinkTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocationFeedbacks", "DrinkTypeId", c => c.Int(nullable: false));
        }
    }
}
