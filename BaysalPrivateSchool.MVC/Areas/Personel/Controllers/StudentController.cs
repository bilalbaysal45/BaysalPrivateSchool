using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Personel.Models;
using BaysalPrivateSchool.MVC.Areas.Student.Models.User;
using BaysalPrivateSchool.MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class StudentController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await StudentDAL.GetAll();
            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddStudentViewModel addStudent)
        {
            if (ModelState.IsValid)
            {
                var response = await StudentDAL.Create(addStudent);
                return View();
            }
            var students = await StudentDAL.GetAll();
            return RedirectToAction("Index", students);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await StudentDAL.GetById(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateStudentViewModel updateStudent)
        {
            if (ModelState.IsValid)
            {
                var response = await StudentDAL.Update(updateStudent);
                // ViewBag.Success = "Success";
                return RedirectToAction("Update", response.Id);
            }
            // ViewBag.Error = "Error";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await StudentDAL.Delete(id);

            var students = await StudentDAL.GetAll();
            return RedirectToAction("Index", "Student", students);
        }
        [HttpGet]
        public async Task<IActionResult> Notes()
        {
            var teacher = await PersonelDAL.GetTeacherWithClass(UserInfo.UserId);
            return View(teacher);
        }
    }
}