using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentClubController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var studentClubs = await StudentClubDAL.GetStudentClubsWithStudentsAndTeachers();
            ViewBag.CurrentUserId = id;
            return View(studentClubs);
        }
        public async Task<IActionResult> Apply(int id)
        {
            var studentClubList = await StudentClubDAL.GetStudentClubsWithStudentsAndTeachers();
            var studentClub = studentClubList.SingleOrDefault(sc => sc.Id == id);
            return View(studentClub);
        }
    }
}