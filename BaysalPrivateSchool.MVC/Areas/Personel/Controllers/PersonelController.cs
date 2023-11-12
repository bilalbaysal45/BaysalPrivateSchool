using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Personel.Models;
using BaysalPrivateSchool.MVC.Data;
using BaysalPrivateSchool.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class PersonelController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var departments = await DepartmentDAL.GetAll();
            ViewBag.Departments = departments;
            return View();
        }
        public IActionResult Create(UpdateTeacherViewModel model) // Update işlemi sonucu buraya geliyor
        {
            AddTeacherViewModel x = new AddTeacherViewModel{FirstName = model.FirstName,LastName=model.LastName};
            return View(x);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddTeacherViewModel newTeacher)
        {
            if(ModelState.IsValid)
            {
                var addedTeacher = await PersonelDAL.Create(newTeacher);
                return View(addedTeacher);
            }
            var departments = await DepartmentDAL.GetAll();
            ViewBag.Departments = departments;
            return View("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var teacher = await PersonelDAL.GetById(id);
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateTeacherViewModel updatedTeacher)
        {
            var response = await PersonelDAL.Update(updatedTeacher);
            return RedirectToAction("Create","Personel", response); //Create' UpdateViewModel gitti
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await PersonelDAL.Delete(id);
            if(response)
            {
                var teachers = await PersonelDAL.GetTeachersWithDepartment();
                return RedirectToAction("Index","Home",teachers);
            }  
            return RedirectToAction("Create","Personel");
        }
    }
}