using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;

namespace StudentManagmentSystem
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
        public string City { get; set; }
    }
}