using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Context;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        ProjectDBContext db = new ProjectDBContext();
        public IActionResult Index()    
        {
            var c = db.courses.ToList();
            return View(c);
        }
        public IActionResult Details(int id)
        {
            var s = db.courses.Include(s => s.Instructor).FirstOrDefault(s => s.Id == id);
            return View(s);
        }
        //Add new Course
        public IActionResult AddNew()
        {
            ViewBag.insts = db.instructors.ToList();
            return View();
        }
        public IActionResult Create(Course c) 
        {
            if (ModelState.IsValid)
            {
                db.courses.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.insts = db.instructors.ToList();
            return View("Addnew",c);
        }
        //edit course
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var c=db.courses.Find(id);
            ViewBag.insts = db.instructors.ToList();
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(Course c)
        {
            if (ModelState.IsValid)
            {
                db.courses.Update(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.insts = db.instructors.ToList();
            return View("Edit", c);
        }

        //delete Course
        public IActionResult Delete(int id)
        {
            var c= db.courses.Find(id);
            db.courses.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
