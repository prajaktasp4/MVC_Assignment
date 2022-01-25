namespace EntityFrameworkExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        CatagoryID = c.Int(nullable: false, identity: true),
                        CatagoryName = c.String(),
                    })
                .PrimaryKey(t => t.CatagoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        DateOfPurchase = c.DateTime(),
                        AvailabilityStatus = c.String(),
                        CatagoryID = c.Int(),
                        BrandID = c.Int(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brands", t => t.BrandID)
                .ForeignKey("dbo.Catagories", t => t.CatagoryID)
                .Index(t => t.CatagoryID)
                .Index(t => t.BrandID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CatagoryID", "dbo.Catagories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "CatagoryID" });
            DropTable("dbo.Products");
            DropTable("dbo.Catagories");
            DropTable("dbo.Brands");
        }
    }
}
