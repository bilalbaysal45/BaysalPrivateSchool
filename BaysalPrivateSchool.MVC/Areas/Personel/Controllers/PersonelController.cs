using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
    }
}