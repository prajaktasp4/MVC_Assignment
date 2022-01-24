using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }
        public Nullable<int> CatagoryID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
       
        public virtual Brand Brand { get; set; }
        public virtual Catagory Catagory { get; set; }
    }
}