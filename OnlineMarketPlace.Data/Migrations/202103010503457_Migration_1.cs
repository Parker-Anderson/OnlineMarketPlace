namespace OnlineMarketPlace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.User", newName: "Person");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Person", newName: "User");
        }
    }
}
