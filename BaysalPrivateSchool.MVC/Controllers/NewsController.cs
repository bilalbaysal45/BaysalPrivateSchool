using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Data;
using BaysalPrivateSchool.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Controllers
{
    public class NewsController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var news = await NewsDAL.GetNews(id);
            return View(news);
        }
    }
}