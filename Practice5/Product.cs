using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkExample.Models
{
    public class Product
    {
        [Display(Name ="Product ID")]
        public int ProductID { get; set; }
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Display(Name ="Price")]
        public Nullable<decimal> Price { get; set; }
        [Display(Name ="Date OF Purchase")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        [Display(Name ="Availabity Status")]
        public string AvailabilityStatus { get; set; }
        [Display(Name ="Catagory ID")]
        public Nullable<int> CatagoryID { get; set; }

        [Display(Name ="Brand ID")]
        public Nullable<int> BrandID { get; set; }
        [Display(Name ="Active")]
        public Nullable<bool> Active { get; set; }
       public Nullable<decimal> Quantity { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Catagory Catagory { get; set; }
    }
}