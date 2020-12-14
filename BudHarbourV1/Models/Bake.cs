using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudHarbourV1.Models
{
    public class Bake
    {
        public int BakeID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}