using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Context;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    public class DepartmentController : Controller
    {
        ProjectDBContext db = new ProjectDBContext();
        public IActionResult Index()
        {
            var c = db.departments.ToList();
            return View(c);
        }
        //Add new Department
        public IActionResult AddNew()
        {
            return View();
        }
        public IActionResult Create(Department d)
        {
            if (ModelState.IsValid)
            {
                db.departments.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddNew",d);
        }
        //edit department
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var d = db.departments.Find(id);
            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(Department d)
        {
            if (ModelState.IsValid)
            {
                db.departments.Update(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit" ,d);
        }

        //delete department
        public IActionResult Delete(int id)
        {
            var d = db.departments.Find(id);
            db.departments.Remove(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
