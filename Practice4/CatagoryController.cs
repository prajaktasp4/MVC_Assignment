using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.Controllers
{
    public class CatagoryController : Controller
    {
        // GET: Catagory
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
           List<Catagory> catagory= db.Catagories.ToList();
            return View(catagory);
        }
    }
}