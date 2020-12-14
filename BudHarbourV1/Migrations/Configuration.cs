namespace BudHarbourV1.Migrations
{
    using BudHarbourV1.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BudHarbourV1.DAL.BudContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BudHarbourV1.DAL.BudContext context)
        {
            var apparels = new List<Apparel>
            {
                new Apparel{ApparelID=1,Name="Bud Harbour Shirt",Price=500,Size="M",Description="Black and white shirt with Bud Harbour logo"},
                new Apparel{ApparelID=2,Name="Bud Harbour Hoodie",Price=800,Size="M",Description="Black and white hoodie with Bud Harbour logo"}
            };
            apparels.ForEach(s => context.Apparels.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var bakes = new List<Bake>
            {
                new Bake{BakeID=1,Name="Chocolate Brownie",Price=20,Description="Brownie with chocolate flavour"},
                new Bake{BakeID=2,Name="Vanilla Cookie",Price=10,Description="Cookie with vanilla flavour"}
            };
            bakes.ForEach(s => context.Bakes.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var hydros = new List<Hydro>
            {
                new Hydro{HydroID=1,Name="Lights",Price=300,Description="Lights for growing plants"},
                new Hydro{HydroID=2,Name="Seeds",Price=100,Description="Seeds for growing vegetables"}
            };
            hydros.ForEach(s => context.Hydros.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var smokes = new List<Smoke>
            {
                new Smoke{SmokeID=1,Name="Bong",Price=200,Description="Glass bong for smoking"},
                new Smoke{SmokeID=2,Name="Rolling paper",Price=10,Description="Paper used for rolling smokes"}
            };
            smokes.ForEach(s => context.Smokes.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
