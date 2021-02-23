namespace OnlineMarketPlace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TRANSNOFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "UserId", "dbo.User");
            DropIndex("dbo.Transaction", new[] { "UserId" });
            DropColumn("dbo.Transaction", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transaction", "UserId");
            AddForeignKey("dbo.Transaction", "UserId", "dbo.User", "ID", cascadeDelete: true);
        }
    }
}
