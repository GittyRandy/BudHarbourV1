namespace BudHarbourV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apparel",
                c => new
                    {
                        ApparelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Size = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ApparelID);
            
            CreateTable(
                "dbo.Bake",
                c => new
                    {
                        BakeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.BakeID);
            
            CreateTable(
                "dbo.Hydro",
                c => new
                    {
                        HydroID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.HydroID);
            
            CreateTable(
                "dbo.Smoke",
                c => new
                    {
                        SmokeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SmokeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Smoke");
            DropTable("dbo.Hydro");
            DropTable("dbo.Bake");
            DropTable("dbo.Apparel");
        }
    }
}
