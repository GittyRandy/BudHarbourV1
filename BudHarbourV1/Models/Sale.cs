using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudHarbourV1.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int ApparelID { get; set; }
        public int BakeID { get; set; }
        public int HydroID { get; set; }
        public int SmokeID { get; set; }
        public int CustomerID { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public virtual Apparel Apparel { get; set; }
        public virtual Bake Bake { get; set; }
        public virtual Hydro Hydro { get; set; }
        public virtual Smoke Smoke { get; set; }
        public virtual Customer Customer { get; set; }
    }
}