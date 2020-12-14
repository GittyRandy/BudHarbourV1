namespace BudHarbourV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApparelStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apparel", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apparel", "Stock");
        }
    }
}
