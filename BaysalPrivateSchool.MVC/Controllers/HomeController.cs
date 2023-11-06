using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaysalPrivateSchool.MVC.Models;
using BaysalPrivateSchool.MVC.Data;

namespace BaysalPrivateSchool.MVC.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        var studentClubsNews = await StudentClubDAL.GetStudentClubsWithNews(); 
        return View(studentClubsNews);
    }

    public async Task<IActionResult> Privacy()
    {
        var info = await SchoolInfoDAL.GetAllSchoolInfos();
        return View(info);
    }
}
