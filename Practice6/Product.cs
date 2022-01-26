using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EntityFrameworkExample.CustomValidations;

namespace EntityFrameworkExample.Models
{
    public class Product
    {
        [Display(Name ="Product ID")]
        
        public int ProductID { get; set; }
        
        [Display(Name ="Product Name")]
        [Required(ErrorMessage ="Product Name Can't be Blank")]
        [RegularExpression(@"^[A-Za-z]*$",ErrorMessage ="Alphabets Only")]
        [MaxLength(40,ErrorMessage ="Length Can't be More than 40 characters")]
        [MinLength(2,ErrorMessage ="Length can't be Less than 2 Characters")]
        public string ProductName { get; set; }

       
        [Display(Name ="Price")]
        [Required(ErrorMessage ="Price Can't be Blank")]
        [Range(10000,100000,ErrorMessage ="Price should be between 10000 to 100000")]
        [DivideBy10Validation(ErrorMessage ="Price Should be multiple of 10")]
        public Nullable<decimal> Price { get; set; }

        
        [Display(Name ="Date OF Purchase")]
       
        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Display(Name ="Availabity Status")]
        [Required(ErrorMessage ="Please Select the Availability Status")]
        public string AvailabilityStatus { get; set; }


        [Display(Name ="Catagory ID")]
        [Required(ErrorMessage ="CatagoryID can't be Blank")]
        public Nullable<int> CatagoryID { get; set; }

        [Display(Name ="Brand ID")]
        [Required(ErrorMessage ="BrandID can't be Blank")]
        public Nullable<int> BrandID { get; set; }

        [Display(Name ="Active")]
        
        public Nullable<bool> Active { get; set; }
       public Nullable<decimal> Quantity { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Catagory Catagory { get; set; }
    }
}