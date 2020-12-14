using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudHarbourV1.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}