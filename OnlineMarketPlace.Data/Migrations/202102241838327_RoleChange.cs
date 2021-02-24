namespace OnlineMarketPlace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.User", "integer");
            DropColumn("dbo.User", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "UserRole", c => c.String(nullable: false));
            AddColumn("dbo.User", "integer", c => c.Int(nullable: false));
            DropColumn("dbo.User", "Role");
        }
    }
}
