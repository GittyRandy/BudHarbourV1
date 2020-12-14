using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudHarbourV1.Models
{
    public class Smoke
    {
        public int SmokeID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}