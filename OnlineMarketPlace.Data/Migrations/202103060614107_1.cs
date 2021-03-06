namespace OnlineMarketPlace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Popularity = c.Double(nullable: false),
                        PriceRange = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DateJoined = c.DateTime(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            AddColumn("dbo.Product", "Name", c => c.String());
            AddColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Product", "HowLongOnMarket", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Product", "Description", c => c.String());
            AddColumn("dbo.Product", "ProductId", c => c.Guid(nullable: false));
            AddColumn("dbo.Product", "PersonId", c => c.Int());
            AddColumn("dbo.Product", "CategoryId", c => c.Int());
            AddColumn("dbo.Transaction", "PersonId", c => c.Int());
            AddColumn("dbo.Transaction", "ProductId", c => c.Int());
            AddColumn("dbo.Transaction", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Transaction", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Transaction", "TransactionId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Product", "PersonId");
            CreateIndex("dbo.Product", "CategoryId");
            CreateIndex("dbo.Transaction", "PersonId");
            CreateIndex("dbo.Transaction", "ProductId");
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "CategoryId");
            AddForeignKey("dbo.Product", "PersonId", "dbo.Person", "PersonId");
            AddForeignKey("dbo.Transaction", "ProductId", "dbo.Product", "ID");
            AddForeignKey("dbo.Transaction", "PersonId", "dbo.Person", "PersonId");
            DropTable("dbo.User");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Transaction", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Transaction", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Transaction", new[] { "ProductId" });
            DropIndex("dbo.Transaction", new[] { "PersonId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Product", new[] { "PersonId" });
            DropColumn("dbo.Transaction", "TransactionId");
            DropColumn("dbo.Transaction", "ModifiedUtc");
            DropColumn("dbo.Transaction", "CreatedUtc");
            DropColumn("dbo.Transaction", "Cost");
            DropColumn("dbo.Transaction", "ProductId");
            DropColumn("dbo.Transaction", "PersonId");
            DropColumn("dbo.Product", "CategoryId");
            DropColumn("dbo.Product", "PersonId");
            DropColumn("dbo.Product", "ProductId");
            DropColumn("dbo.Product", "Description");
            DropColumn("dbo.Product", "HowLongOnMarket");
            DropColumn("dbo.Product", "Price");
            DropColumn("dbo.Product", "Name");
            DropTable("dbo.Person");
            DropTable("dbo.Category");
        }
    }
}
