using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudHarbourV1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BudHarbourV1.DAL
{
    public class BudContext : DbContext
    {
        public BudContext() : base("BudContext")
        {
        }
        public DbSet<Apparel> Apparels { get; set; }
        public DbSet<Bake> Bakes { get; set; }
        public DbSet<Hydro> Hydros { get; set; }
        public DbSet<Smoke> Smokes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}