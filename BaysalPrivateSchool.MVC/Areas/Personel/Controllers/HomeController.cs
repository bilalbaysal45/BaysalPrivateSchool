using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var response = await PersonelDAL.GetTeachersWithDepartment();
            return View(response);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}