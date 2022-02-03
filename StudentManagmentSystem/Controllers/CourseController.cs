using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagmentSystem.Models;

namespace StudentManagmentSystem.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            StudentDBEntities db = new StudentDBEntities();
            List<Course> course =db.Courses.ToList();

            return View(course);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course c)
        {
            StudentDBEntities db=new StudentDBEntities();
            //if (db.Courses.Where(temp => temp.CourseName == c.CourseName).FirstOrDefault() == null)
            //{
                db.Courses.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //else
            //{
            //    return RedirectToAction("Error","Create");
            //}

        }
        public ActionResult Edit(long id)
        {
            StudentDBEntities db = new StudentDBEntities();
            Course c = db.Courses.Where(temp=>temp.CourseID==id).FirstOrDefault();
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Course c)
        {
            StudentDBEntities db = new StudentDBEntities();
            Course course= db.Courses.Where(temp=>temp.CourseID==c.CourseID).FirstOrDefault();
            course.CourseName=c.CourseName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            StudentDBEntities db = new StudentDBEntities();
            Course c = db.Courses.Where(temp => temp.CourseID == id).FirstOrDefault();
            db.Courses.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}