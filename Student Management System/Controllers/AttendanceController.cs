using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Context;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        ProjectDBContext db = new ProjectDBContext();
        public IActionResult Index()
        {
            var e = db.attendances.ToList();
            return View(e);
        }

        public IActionResult Details(int id)
        {
            var a = db.attendances.Include(e => e.student).Include(e => e.course).FirstOrDefault(e => e.Id == id);
            return View(a);
        }

        //Add new Attendance
        [HttpGet]
        public IActionResult AddNew()
        {
            ViewBag.students = db.students.ToList();
            ViewBag.courses = db.courses.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Attendance a)
        {
            if (ModelState.IsValid)
            {
                db.attendances.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.students = db.students.ToList();
            ViewBag.courses = db.courses.ToList();
            return View("AddNew",a);
        }

        //edit Attendance
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var a = db.attendances.Find(id);
            ViewBag.students = db.students.ToList();
            ViewBag.courses = db.courses.ToList();
            return View(a);
        }
        [HttpPost]
        public IActionResult Edit(Attendance a)
        {
            if (ModelState.IsValid)
            {
                db.attendances.Update(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.students = db.students.ToList();
            ViewBag.courses = db.courses.ToList();
            return View("Edit",a);
        }

        //delete Attendance
        public IActionResult Delete(int id)
        {
            var a = db.attendances.Find(id);
            db.attendances.Remove(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CheckFutureDate(DateTime Date)
        {
            if (Date.Year > 2025) return Json(false);
            return Json(true);
        }
    }
}
