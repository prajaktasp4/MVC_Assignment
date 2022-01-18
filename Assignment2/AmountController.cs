using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_app.Controllers
{
    public class AmountController : Controller
    {
        // GET: Amount
        public ActionResult Currency(int amt)
        {
            ViewBag.Amount = amt;
            return View();
        }
    }
}