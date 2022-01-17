using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_app.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string username,string password)
        {
            if(username=="admin" && password=="admin@123")
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                return RedirectToAction("InvalidLogin");
            }
           
        }

        public ActionResult InvalidLogin()
        {
            return View();
        }
    }
}