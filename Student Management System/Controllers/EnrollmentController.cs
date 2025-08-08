using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Context;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    [Authorize]
    public class EnrollmentController : Controller
    {
        ProjectDBContext db = new ProjectDBContext();
        public IActionResult Index()
        {
            var e = db.enrollments.ToList();
            return View(e);
        }
        
        public IActionResult Details(int id)
        {
            var e=db.enrollments.Include(e=>e.student).Include(e=>e.course).FirstOrDefault(e=>e.Id==id);
            return View(e);
        }

        //Add new Enrollment
        [HttpGet]
        public IActionResult AddNew()
        {
            ViewBag.students = db.students.ToList();
            ViewBag.courses = db.courses.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Enrollment e)
        {
            if (ModelState.IsValid)
            {
                db.enrollments.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.students = db.students.ToList();
            ViewBag.courses = db.courses.ToList();
            return View("AddNew",e);
        }

        //edit Enrollment
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var e = db.enrollments.Find(id);
            ViewBag.students = db.students.ToList();
            ViewBag.courses = db.courses.ToList();
            return View(e);
        }
        [HttpPost]
        public IActionResult Edit(Enrollment e)
        {
            if (ModelState.IsValid)
            {
                db.enrollments.Update(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.students = db.students.ToList();
            ViewBag.courses = db.courses.ToList();
            return View("Edit",e);  
        }

        //delete Enrollment
        public IActionResult Delete(int id)
        {
            var e =db.enrollments.Find(id);
            db.enrollments.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
