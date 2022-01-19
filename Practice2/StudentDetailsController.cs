using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_app.Controllers
{
    public class StudentDetailsController : Controller
    {
        // GET: StudentDetails
        public ActionResult Details()
        {
            ViewBag.StudentId = 101;
            ViewBag.StudentName = "Allen";
            ViewBag.StudentMarks = 60;
            ViewBag.NoOfSemester = 6;
            ViewBag.Subjects=new List<string>() { "Physics","Chemistry","Maths","Biology"};
            return View();
        }
    }
}