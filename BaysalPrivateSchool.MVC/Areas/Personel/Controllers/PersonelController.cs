using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Personel.Models;
using BaysalPrivateSchool.MVC.Areas.Student.Models.User;
using BaysalPrivateSchool.MVC.Data;
using BaysalPrivateSchool.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class PersonelController : Controller
    {
        public IActionResult Index(UpdateTeacherViewModel model) // Update işlemi sonucu buraya geliyor
        {
            // var departments = await DepartmentDAL.GetAll();
            // ViewBag.Departments = departments;
            // return View();
            AddTeacherViewModel x = new AddTeacherViewModel { FirstName = model.FirstName, LastName = model.LastName };
            return View(x);
        }
        public async Task<IActionResult> Create() 
        {
            var departments = await DepartmentDAL.GetAll();
            ViewBag.Departments = departments;
            return View();
            // AddTeacherViewModel x = new AddTeacherViewModel { FirstName = model.FirstName, LastName = model.LastName };
            // return View(x);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddTeacherViewModel newTeacher)
        {
            if (ModelState.IsValid)
            {
                var addedTeacher = await PersonelDAL.Create(newTeacher);
                return RedirectToAction("Index","Home",new {area="Personel",id=UserInfo.UserId});
            }
            var departments = await DepartmentDAL.GetAll();
            ViewBag.Departments = departments;
            return View(newTeacher);
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
            if (ModelState.IsValid)
            {
                var response = await PersonelDAL.Update(updatedTeacher);
                return RedirectToAction("Index", "Personel", response); //Create' UpdateViewModel gitti
            }
            return View(updatedTeacher);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await PersonelDAL.Delete(id);
            if (response)
            {
                var teachers = await PersonelDAL.GetTeachersWithDepartment();
                return RedirectToAction("Index", "Home", teachers);
            }
            return RedirectToAction("Create", "Personel");
        }
    }
}