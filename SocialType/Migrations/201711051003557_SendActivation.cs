namespace SocialType.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SendActivation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActivations",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        ActivationCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserActivations");
        }
    }
}
