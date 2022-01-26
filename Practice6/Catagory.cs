using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EntityFrameworkExample.Models
{
    public class Catagory
    {
        [Key]
        public int CatagoryID { get; set; }
        public string CatagoryName { get; set; }
    }
}