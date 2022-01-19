using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_app.Controllers
{
    public class RequestObjectController : Controller
    {
        // GET: RequestObject
        public ActionResult Index()
        {
            ViewBag.url = Request.Url;
            ViewBag.physicalpath = Request.PhysicalApplicationPath;
            ViewBag.path= Request.Path;
            ViewBag.browser= Request.Browser.Type;
            ViewBag.querystring = Request.QueryString["n"];
            ViewBag.header = Request.Headers["Accept"];
            ViewBag.method = Request.HttpMethod;
            return View();
        }
    }
}