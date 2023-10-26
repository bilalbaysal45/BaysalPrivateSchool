using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaysalPrivateSchool.MVC.Models;

namespace BaysalPrivateSchool.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
