namespace EntityFrameworkExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredValidation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Products", "CatagoryID", "dbo.Catagories");
            DropIndex("dbo.Products", new[] { "CatagoryID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "AvailabilityStatus", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "CatagoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BrandID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Active", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Products", "CatagoryID");
            CreateIndex("dbo.Products", "BrandID");
            AddForeignKey("dbo.Products", "BrandID", "dbo.Brands", "BrandID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CatagoryID", "dbo.Catagories", "CatagoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CatagoryID", "dbo.Catagories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "CatagoryID" });
            AlterColumn("dbo.Products", "Active", c => c.Boolean());
            AlterColumn("dbo.Products", "BrandID", c => c.Int());
            AlterColumn("dbo.Products", "CatagoryID", c => c.Int());
            AlterColumn("dbo.Products", "AvailabilityStatus", c => c.String());
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime());
            AlterColumn("dbo.Products", "Price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            CreateIndex("dbo.Products", "BrandID");
            CreateIndex("dbo.Products", "CatagoryID");
            AddForeignKey("dbo.Products", "CatagoryID", "dbo.Catagories", "CatagoryID");
            AddForeignKey("dbo.Products", "BrandID", "dbo.Brands", "BrandID");
        }
    }
}
