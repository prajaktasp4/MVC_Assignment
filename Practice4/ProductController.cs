using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string search = "")
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            ViewBag.search = search;
            List<Product> product = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            return View(product);
        }
        public ActionResult Details(int id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product existingproduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(existingproduct);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product existingproduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            existingproduct.ProductName = p.ProductName;
            existingproduct.Price = p.Price;
            existingproduct.DateOfPurchase = p.DateOfPurchase;
            existingproduct.AvailabilityStatus = p.AvailabilityStatus;
            existingproduct.CatagoryID = p.CatagoryID;
            existingproduct.BrandID = p.BrandID;
            existingproduct.Active = p.Active;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product existingproduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(existingproduct);
        }
        [HttpPost]
        public ActionResult Delete(int id,Product p)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product existingproduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            db.Products.Remove(existingproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}