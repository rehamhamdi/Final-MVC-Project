using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Context;
using Student_Management_System.Models;
using Student_Management_System.Repositories;

namespace Student_Management_System.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentRepository repo ;
        public DepartmentController(DepartmentRepository _repo)
        {
            repo= _repo;
        }
        public IActionResult Index()
        {
            var c = repo.ReadAll();
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
                repo.Create(d);
                repo.save();
                return RedirectToAction("Index");
            }
            return View("AddNew",d);
        }
        //edit department
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var d = repo.ReadById(id);
            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(Department d)
        {
            if (ModelState.IsValid)
            {
                repo.Update(d);
                repo.save();
                return RedirectToAction("Index");
            }
            return View("Edit" ,d);
        }

        //delete department
        public IActionResult Delete(int id)
        {
            var d = repo.ReadById(id);
            repo.Delete(d);
            repo.save();
            return RedirectToAction("Index");
        }
    }
}
