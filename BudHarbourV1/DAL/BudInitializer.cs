using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BudHarbourV1.Models;

namespace BudHarbourV1.DAL
{
    public class BudInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BudContext>
    {
        protected override void Seed(BudContext context)
        {
            var apparels = new List<Apparel>
            {
                new Apparel{ApparelID=1,Name="Bud Harbour Shirt",Price=500,Size="M",Description="Black and white shirt with Bud Harbour logo"},
                new Apparel{ApparelID=2,Name="Bud Harbour Hoodie",Price=800,Size="M",Description="Black and white hoodie with Bud Harbour logo"}
            };
            apparels.ForEach(s => context.Apparels.Add(s));
            context.SaveChanges();

            var bakes = new List<Bake>
            {
                new Bake{BakeID=1,Name="Chocolate Brownie",Price=20,Description="Brownie with chocolate flavour"},
                new Bake{BakeID=2,Name="Vanilla Cookie",Price=10,Description="Cookie with vanilla flavour"}
            };
            bakes.ForEach(s => context.Bakes.Add(s));
            context.SaveChanges();

            var hydros = new List<Hydro>
            {
                new Hydro{HydroID=1,Name="Lights",Price=300,Description="Lights for growing plants"},
                new Hydro{HydroID=2,Name="Seeds",Price=100,Description="Seeds for growing vegetables"}
            };
            hydros.ForEach(s => context.Hydros.Add(s));
            context.SaveChanges();

            var smokes = new List<Smoke>
            {
                new Smoke{SmokeID=1,Name="Bong",Price=200,Description="Glass bong for smoking"},
                new Smoke{SmokeID=2,Name="Rolling paper",Price=10,Description="Paper used for rolling smokes"}
            };
            hydros.ForEach(s => context.Hydros.Add(s));
            context.SaveChanges();
        }
    }
}