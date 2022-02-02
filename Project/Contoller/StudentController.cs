using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagmentSystem.Models;
using System.IO;
using System.Net;

namespace StudentManagmentSystem.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        



        public ActionResult Student(string search = "", string SortColumn = "FullName", string IconClass = "fa-sort-asc",int PageNo=1)
        {
            StudentDBEntities db = new StudentDBEntities();
            ViewBag.search = search;
            List<Student> student = db.Students.Where(temp => temp.FullName.Contains(search)).ToList();

            
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "StudentID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    student = student.OrderBy(temp => temp.StudentID).ToList();
                else
                    student = student.OrderByDescending(temp => temp.StudentID).ToList();
            }
            else if (ViewBag.SortColumn == "FullName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    student = student.OrderBy(temp => temp.FullName).ToList();
                else
                    student = student.OrderByDescending(temp => temp.FullName).ToList();
            }
            else if (ViewBag.SortColumn == "UserID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    student = student.OrderBy(temp => temp.UserID).ToList();
                else
                    student = student.OrderByDescending(temp => temp.UserID).ToList();
            }
            else if (ViewBag.SortColumn == "EmailID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    student = student.OrderBy(temp => temp.EmailID).ToList();
                else
                    student = student.OrderByDescending(temp => temp.EmailID).ToList();
            }
            else if (ViewBag.SortColumn == "DateOFBirth")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    student = student.OrderBy(temp => temp.DateOFBirth).ToList();
                else
                    student = student.OrderByDescending(temp => temp.DateOFBirth).ToList();
            }
            else if (ViewBag.SortColumn == "Gender")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    student = student.OrderBy(temp => temp.Gender).ToList();
                else
                    student = student.OrderByDescending(temp => temp.Gender).ToList();
            }
            else if (ViewBag.SortColumn == "Address")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    student = student.OrderBy(temp => temp.Address).ToList();
                else
                    student = student.OrderByDescending(temp => temp.Address).ToList();
            }
            else if (ViewBag.SortColumn == "PhoneNo")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    student = student.OrderBy(temp => temp.PhoneNo).ToList();
                else
                    student = student.OrderByDescending(temp => temp.PhoneNo).ToList();
            }
            else if (ViewBag.SortColumn == "PreviousQualification")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    student = student.OrderBy(temp => temp.PreviousQualification).ToList();
                else
                    student = student.OrderByDescending(temp => temp.PreviousQualification).ToList();
            }


            else
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    student = student.OrderBy(temp => temp.Course.CourseName).ToList();
                else
                    student = student.OrderByDescending(temp => temp.Course.CourseName).ToList();
            }

            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(student.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfPagesToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            student = student.Skip(NoOfPagesToSkip).Take(NoOfRecordsPerPage).ToList();

            return View(student);
        }








        public ActionResult Details( long id)
        {
            StudentDBEntities db= new StudentDBEntities();
            Student p = db.Students.Where(temp=>temp.StudentID==id).FirstOrDefault();
            return View(p);
        }

        public ActionResult Create()
        {

            StudentDBEntities db = new StudentDBEntities();
            ViewBag.course = db.Courses.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind (Include ="StudentID,FullName,UserID,EmailID,DateOFBirth,Gender,Address,PhoneNo,PreviousQualification,CourseID")]Student s, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                StudentDBEntities db = new StudentDBEntities();

                string filename = Path.GetFileName(file.FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;

                string extension = Path.GetExtension(file.FileName);

                string path = Path.Combine(Server.MapPath("~/images/"), _filename);

                s.Photo = "~/images/" + _filename;

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    if (file.ContentLength <= 1000000)
                    {
                        db.Students.Add(s);

                        if (db.SaveChanges() > 0)
                        {
                            file.SaveAs(path);
                            ViewBag.msg = "Employee Added";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        ViewBag.msg = "File Size must be Equal or less than 1mb";
                    }
                }
                else
                {
                    ViewBag.msg = "Inavlid File Type";
                }

                //if (Request.Files.Count >= 1)
                //{
                //    var file = Request.Files[0];
                //    var ImgBytes = new Byte[file.ContentLength];
                //    file.InputStream.Read(ImgBytes, 0, file.ContentLength);
                //    var Base64String = Convert.ToBase64String(ImgBytes, 0, ImgBytes.Length);
                //    s.Photo = Base64String;
                //}
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Student");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(long id)
        {
            StudentDBEntities db = new StudentDBEntities();
            ViewBag.course = db.Courses.ToList();
            Student s= db.Students.Where(temp=>temp.StudentID == id).FirstOrDefault();
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            StudentDBEntities db = new StudentDBEntities();
            Student existing =db.Students.Where(temp=>temp.StudentID==s.StudentID).FirstOrDefault();
            existing.FullName= s.FullName;
            existing.UserID=s.UserID;
            existing.EmailID = s.EmailID;
            existing.DateOFBirth=s.DateOFBirth;
            existing.Gender=s.Gender;
            existing.Address = s.Address;
            existing.PhoneNo = s.PhoneNo;
            existing.PreviousQualification=s.PreviousQualification;
            existing.CourseID = s.CourseID;
            db.SaveChanges();
            return RedirectToAction("student");
            
        }

        public ActionResult Delete(long id)
        {
            StudentDBEntities db = new StudentDBEntities();
            Student p = db.Students.Where(temp => temp.StudentID == id).FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(long id,Student s)
        {
            StudentDBEntities db = new StudentDBEntities();
            Student p = db.Students.Where(temp => temp.StudentID == id).FirstOrDefault();
            db.Students.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Student");
        }





    }
}