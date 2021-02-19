namespace OnlineMarketPlace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserID");
        }
    }
}
