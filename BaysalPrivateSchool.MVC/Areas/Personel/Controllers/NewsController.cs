using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Personel.Models.NewsModel;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(AddNewsViewModel addNews)
        {
            if(ModelState.IsValid)
            {
                var studentClub = await PersonelDAL.GetStudentClubWithNewsByTeacherId(UserInfo.UserId);
                addNews.StudentClubId = studentClub.Data.Id;
                string[] clubName = studentClub.Data.Name.Split(' ');
                addNews.Name  = clubName[0];
                var response = await NewsDAL.Create(addNews);
                return RedirectToAction("Index");
            }
            return View(addNews);
        }
        public async Task<IActionResult> Update(int id)
        {
            var news = await NewsDAL.GetById(id);
            return View(news);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateNewsViewModel updateNews)
        {
            if(ModelState.IsValid)
            {
                var response = await NewsDAL.Update(updateNews);
                return RedirectToAction("Index");
            }
            return View(updateNews);
        }

    }
}