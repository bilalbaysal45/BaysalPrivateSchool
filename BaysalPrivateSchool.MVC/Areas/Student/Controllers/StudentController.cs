using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BaysalPrivateSchool.MVC.Areas.Personel.Models;
using BaysalPrivateSchool.MVC.Data;
using BaysalPrivateSchool.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentController : Controller
    {
        private static int _userId;
        public async Task<IActionResult> Index(int id)
        {
            var student = await StudentDAL.GetById(id);
            ViewBag.UserId = id;
            _userId = id;
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> AppliedClub(int id)
        {
            var response = await StudentDAL.ChangeStudentClub(new ChangeStudentClubViewModel { Id = _userId, StudentClubId = id });

            return RedirectToAction("Index", "Student", new { area = "Student", id = _userId });
        }
        [HttpGet]
        public async Task<IActionResult> Note(int id)
        {
            var response = await StudentDAL.GetStudentWithNotes(id);
            return View(response);
        }
    }
}