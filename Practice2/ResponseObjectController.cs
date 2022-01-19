using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_app.Controllers
{
    public class ResponseObjectController : Controller
    {
        // GET: ResponseObject
        public ActionResult Index()
        {
            Response.Write("Hello from response on object");
            Response.ContentType = "text/plain";
            Response.Headers["server"]="Myserver";
            Response.StatusCode = 500;
            return View();
        }
    }
}