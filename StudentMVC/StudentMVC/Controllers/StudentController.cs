using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;
using StudentMVC.Services;
using System;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentService;

        public StudentController(IStudentServices studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentService.Insert(model);
                return RedirectToAction("GetStudents");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var products = _studentService.GetAll();
            return View(products);
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return RedirectToAction("GetStudents");
        }

        public IActionResult GetById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Update()
        {
           
            return View(new Student()); 
        }

        
        [HttpPost]
        public IActionResult Update(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentService.Update(model);
                return RedirectToAction("GetStudents");
            }
            return View(model); 
        }



    }
}
