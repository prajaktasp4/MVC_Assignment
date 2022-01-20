using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelExample1.Models;

namespace ModelExample1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Products> product = new List<Products>()
            {
                new Products(){ProductId=1,ProductName="Iphone",Rate=50000},
                new Products(){ProductId=2,ProductName="Printer",Rate =60000},
                new Products(){ProductId=3,ProductName="Home Appliances",Rate=80000}
            };

            
            return View(product);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            List<Products> product = new List<Products>()
            {
                new Products(){ProductId=1,ProductName="Iphone",Rate=50000},
                new Products(){ProductId=2,ProductName="Printer",Rate =60000},
                new Products(){ProductId=3,ProductName="Home Appliances",Rate=80000}
            };
            Products matchingitem = null;
            foreach (var p in product)
            {
                
                if(p.ProductId == id)
                {
                    matchingitem = p;
                }
                
            }
            
            return View(matchingitem);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include ="ProductId,ProductName")]Products p)
        {
            return View();
        }
    }
}