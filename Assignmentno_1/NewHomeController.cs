using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_app.Controllers
{
    public class NewHomeController : Controller
    {
        // GET: NewHome
        public ActionResult Index(string str)
        {
           

                if (str == "Sample")
                {
                    String filepath = "~/Sample.pdf";
                    return File(filepath, "application/pdf");
                }
                else if (str == "gotoabout")
                {
                    return RedirectToAction("About");
                }

                else if (str == "login")
                {
                    return View();

                }

                else
                {
                    return Content("You Entered :" + str);
                }
            
            return View();

        }
        public ActionResult About()
        {
            return Content("About content here");
        }
    }
}