using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaysalPrivateSchool.MVC.Models;
using BaysalPrivateSchool.MVC.Data;

namespace BaysalPrivateSchool.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Privacy()
    {
        var info = await SchoolInfoDAL.GetAllSchoolInfos();
        return View(info);
    }
}
