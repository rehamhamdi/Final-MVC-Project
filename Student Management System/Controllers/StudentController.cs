using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Context;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    public class StudentController : Controller
    {
        ProjectDBContext db=new ProjectDBContext();
        public IActionResult Index()
        {
            var student = db.students.ToList();
            return View(student);
        }
        public IActionResult Details(int id)
        {
            var s = db.students.Include(s=>s.department).FirstOrDefault(s=>s.Id==id);
            return View(s);
        }
        //Add New Student
        public IActionResult AddNew()
        {
            ViewBag.depts=db.departments.ToList();
            return View();
        }
        
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            { 
            db.students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            ViewBag.depts = db.departments.ToList();
            return View("AddNew", s);
        }
        //edit student
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var s = db.students.Find(id);
            ViewBag.depts = db.departments.ToList();
            return View(s);
        }
        [HttpPost]
        public IActionResult Edit(Student s) 
        {
            if (ModelState.IsValid)
            {
                db.Update(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depts = db.departments.ToList();
            return View("Edit",s);
        }

        //delete student
        public IActionResult Delete(int id)
        {
            var s = db.students.Find(id);
            db.students.Remove(s);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult CheckDate(DateTime DateOfBirth)
        {
            if (DateOfBirth.Year > 2010) return Json(false);
            return Json(true);
        }


    }
}
