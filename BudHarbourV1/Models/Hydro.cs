using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudHarbourV1.Models
{
    public class Hydro
    {
        public int HydroID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}