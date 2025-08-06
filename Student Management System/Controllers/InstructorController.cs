using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Context;
using Student_Management_System.Models;
using Student_Management_System.Repositories;

namespace Student_Management_System.Controllers
{
    public class InstructorController : Controller
    {
        InstructorRepository repo;
        public InstructorController(InstructorRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            var i = repo.ReadAll();
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
                repo.Create(i);
                repo.save();
                return RedirectToAction("Index");
            }
            return View("AddNew");
        }
        //edit Instructor
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var i = repo.ReadById(id);
            return View(i);
        }
        [HttpPost]
        public IActionResult Edit(Instructor i)
        {
            if (ModelState.IsValid)
            {
                repo.Update(i);
                repo.save();
                return RedirectToAction("Index");
            }
            return View("Edit",i);
        }

        //delete Instructor
        public IActionResult Delete(int id)
        {
            var i = repo.ReadById(id);
            repo.Delete(i);
            repo.save();
            return RedirectToAction("Index");
        }

        public IActionResult CheckFutureDate(DateTime HireDate)
        {
            if (HireDate.Year > 2025) return Json(false);
            return Json(true);
        }
    }
}
