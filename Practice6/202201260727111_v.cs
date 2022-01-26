namespace EntityFrameworkExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime());
            AlterColumn("dbo.Products", "AvailabilityStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "AvailabilityStatus", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
    }
}
