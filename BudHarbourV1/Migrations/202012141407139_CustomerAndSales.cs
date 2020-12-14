namespace BudHarbourV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAndSales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        ApparelID = c.Int(nullable: false),
                        BakeID = c.Int(nullable: false),
                        HydroID = c.Int(nullable: false),
                        SmokeID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.Apparel", t => t.ApparelID, cascadeDelete: true)
                .ForeignKey("dbo.Bake", t => t.BakeID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Hydro", t => t.HydroID, cascadeDelete: true)
                .ForeignKey("dbo.Smoke", t => t.SmokeID, cascadeDelete: true)
                .Index(t => t.ApparelID)
                .Index(t => t.BakeID)
                .Index(t => t.HydroID)
                .Index(t => t.SmokeID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sale", "SmokeID", "dbo.Smoke");
            DropForeignKey("dbo.Sale", "HydroID", "dbo.Hydro");
            DropForeignKey("dbo.Sale", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Sale", "BakeID", "dbo.Bake");
            DropForeignKey("dbo.Sale", "ApparelID", "dbo.Apparel");
            DropIndex("dbo.Sale", new[] { "CustomerID" });
            DropIndex("dbo.Sale", new[] { "SmokeID" });
            DropIndex("dbo.Sale", new[] { "HydroID" });
            DropIndex("dbo.Sale", new[] { "BakeID" });
            DropIndex("dbo.Sale", new[] { "ApparelID" });
            DropTable("dbo.Customer");
            DropTable("dbo.Sale");
        }
    }
}
