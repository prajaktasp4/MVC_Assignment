using System;
using System.Collections.Generic;
              
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkExample.Models;

namespace EntityFrameWorkExample.Controllers
{
    public class ProductController : Controller
    {
        // GET: Products/Index
        public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass = "fa-sort-asc")
        {
            CompanyDbContext db = new CompanyDbContext();
            ViewBag.search = search;
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();

            /*Sorting*/
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DateOfPurchase).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Catagory.CatagoryName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Catagory.CatagoryName).ToList();
            }
            else  
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Brand.BrandName).ToList();
            }

            return View(products);
        }

        public ActionResult Details(long id)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }

        public ActionResult Create()
        {
            CompanyDbContext db = new CompanyDbContext();
            ViewBag.Categories = db.Catagories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            CompanyDbContext db = new CompanyDbContext();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            ViewBag.Categories = db.Catagories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.CatagoryID = p.CatagoryID;
            existingProduct.BrandID = p.BrandID;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public ActionResult Delete(long id)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(long id, Product p)
        {
            CompanyDbContext db = new CompanyDbContext();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}

