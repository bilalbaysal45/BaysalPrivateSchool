using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Controllers
{
    public class PersonelController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var personel = await PersonelDAL.GetTeachersWithDepartment();
            return View(personel);
        }
    }
}