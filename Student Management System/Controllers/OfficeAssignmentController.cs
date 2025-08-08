using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Context;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    [Authorize]
    public class OfficeAssignmentController : Controller
    {
        ProjectDBContext db = new ProjectDBContext();
        public IActionResult Index()
        {
            var o = db.officeAssignments.ToList();
            return View(o);
        }
        public IActionResult Details(int id)
        {
            var o = db.officeAssignments.Include(s => s.instructor).FirstOrDefault(s => s.Id == id);
            return View(o);
        }

        //Add New Office
        public IActionResult AddNew()
        {
            ViewBag.insts = db.instructors.ToList();
            return View();
        }

        public IActionResult Create(OfficeAssignment o)
        {
            if (ModelState.IsValid)
            {
                db.officeAssignments.Add(o);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.insts = db.instructors.ToList();
            return View("AddNew", o);
        }
        //edit Office
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var o = db.officeAssignments.Find(id);
            ViewBag.insts = db.instructors.ToList();

            return View(o);
        }
        [HttpPost]
        public IActionResult Edit(OfficeAssignment o)
        {
            if (ModelState.IsValid)
            {
                db.Update(o);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.insts = db.instructors.ToList();
            return View("Edit" ,o);
        }

        //delete Office
        public IActionResult Delete(int id)
        {
            var o = db.officeAssignments.Find(id);
            db.officeAssignments.Remove(o);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
