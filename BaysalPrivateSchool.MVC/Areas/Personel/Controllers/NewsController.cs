using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Student.Models.User;
using BaysalPrivateSchool.MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class NewsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var studentClub = await PersonelDAL.GetStudentClubWithNewsByTeacherId(UserInfo.UserId);
            return View(studentClub);
        }
        public async Task<IActionResult> AllNews(int id)
        {
            var studentClubWithNews = await StudentClubDAL.GetStudentClubWithNews(id);
            return View(studentClubWithNews);
        }

    }
}