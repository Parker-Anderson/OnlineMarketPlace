namespace OnlineMarketPlace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_2257 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "PersonId", "dbo.User");
            DropIndex("dbo.Transaction", new[] { "PersonId" });
            AddColumn("dbo.Transaction", "ProductId", c => c.Int());
            AlterColumn("dbo.Transaction", "PersonId", c => c.Int());
            CreateIndex("dbo.Transaction", "PersonId");
            CreateIndex("dbo.Transaction", "ProductId");
            AddForeignKey("dbo.Transaction", "ProductId", "dbo.Product", "ID");
            AddForeignKey("dbo.Transaction", "PersonId", "dbo.User", "PersonId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "PersonId", "dbo.User");
            DropForeignKey("dbo.Transaction", "ProductId", "dbo.Product");
            DropIndex("dbo.Transaction", new[] { "ProductId" });
            DropIndex("dbo.Transaction", new[] { "PersonId" });
            AlterColumn("dbo.Transaction", "PersonId", c => c.Int(nullable: false));
            DropColumn("dbo.Transaction", "ProductId");
            CreateIndex("dbo.Transaction", "PersonId");
            AddForeignKey("dbo.Transaction", "PersonId", "dbo.User", "PersonId", cascadeDelete: true);
        }
    }
}
