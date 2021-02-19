namespace OnlineMarketPlace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Transaction", new[] { "Product_Id" });
            AddColumn("dbo.Transaction", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            CreateIndex("dbo.Transaction", "Product_ID");
            DropColumn("dbo.Product", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Category", c => c.Int(nullable: false));
            DropIndex("dbo.Transaction", new[] { "Product_ID" });
            DropColumn("dbo.Transaction", "ModifiedUtc");
            CreateIndex("dbo.Transaction", "Product_Id");
        }
    }
}
