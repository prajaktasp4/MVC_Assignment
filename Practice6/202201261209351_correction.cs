namespace EntityFrameworkExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Active", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Active", c => c.Boolean(nullable: false));
        }
    }
}
