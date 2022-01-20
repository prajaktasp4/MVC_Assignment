using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewLayoutDemo.Controllers
{
    public class home1Controller : Controller
    {
        // GET: home1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Profile()

        {
            return View();
        }
    }
}