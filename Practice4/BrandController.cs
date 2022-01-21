using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            List<Brand>Brand= db.Brands.ToList();
            return View(Brand);
        }
    }
}