namespace OnlineMarketPlace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_2255 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Product", "PersonId", "dbo.User");
            DropIndex("dbo.Product", new[] { "PersonId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            AlterColumn("dbo.Product", "PersonId", c => c.Int());
            AlterColumn("dbo.Product", "CategoryId", c => c.Int());
            CreateIndex("dbo.Product", "PersonId");
            CreateIndex("dbo.Product", "CategoryId");
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "CategoryId");
            AddForeignKey("dbo.Product", "PersonId", "dbo.User", "PersonId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "PersonId", "dbo.User");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Product", new[] { "PersonId" });
            AlterColumn("dbo.Product", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "CategoryId");
            CreateIndex("dbo.Product", "PersonId");
            AddForeignKey("dbo.Product", "PersonId", "dbo.User", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
    }
}
