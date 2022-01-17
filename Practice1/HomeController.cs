using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_app.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View("CompanyProduct");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetEmpName(int EmpId)
        {
            var Emp = new[]
            {
                new  { EmpId =1,EmpName="Scot",Salary=20000 },
                new { EmpId =2,EmpName="Smith",Salary=30000},
                new  { EmpId =3,EmpName="Allen",Salary=50000}
            };
            string MatchEmpName = null;

            foreach(var item in Emp)
            {
                if(item.EmpId == EmpId)
                {
                    MatchEmpName= item.EmpName;
                }

            }
            return Content(MatchEmpName,"plain/text");
        }

        public ActionResult GetPaySlip(int EmpId)
        {
            string FileName = "~/PaySlip" + EmpId + ".pdf";
            return File(FileName, "application/pdf");


        }

        public ActionResult EmpFacebookPage(int EmpId)
        {
            var Emp = new[]
            {
                new  { EmpId =1,EmpName="Scot",Salary=20000 },
                new { EmpId =2,EmpName="Smith",Salary=30000},
                new  { EmpId =3,EmpName="Allen",Salary=50000}
            };
            string fburl = null;
            foreach (var item in Emp)
            {
                if(item.EmpId==EmpId)
                {
                    fburl = "http://www.facebook.com.emp" + EmpId;
                }
            }
            if(fburl != null)
            {
                return Content("Invalid Employee id");
            }
            else
            {
                return Redirect(fburl);
            }

           
        }


    }
}