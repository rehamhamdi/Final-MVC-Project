using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Context;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    public class InstructorController : Controller
    {
        ProjectDBContext db = new ProjectDBContext();
        public IActionResult Index()
        {
            var i = db.instructors.ToList();
            return View(i);
        }
        //Add new Instructor
        public IActionResult AddNew()
        {
            return View();
        }
        public IActionResult Create(Instructor i)
        {
            if (ModelState.IsValid)
            {
                db.instructors.Add(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddNew");
        }
        //edit Instructor
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var i = db.instructors.Find(id);
            return View(i);
        }
        [HttpPost]
        public IActionResult Edit(Instructor i)
        {
            if (ModelState.IsValid)
            {
                db.instructors.Update(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit",i);
        }

        //delete Instructor
        public IActionResult Delete(int id)
        {
            var i = db.instructors.Find(id);
            db.instructors.Remove(i);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CheckFutureDate(DateTime HireDate)
        {
            if (HireDate.Year > 2025) return Json(false);
            return Json(true);
        }
    }
}
