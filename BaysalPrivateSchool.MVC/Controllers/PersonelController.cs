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
    public class PersonelController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var personel = await PersonelDAL.GetTeachersWithDepartment();
            return View(personel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email,string password)
        {
            bool login = false;
            var loginCredentials = new LoginViewModel();
            loginCredentials.Email = email;
            loginCredentials.Password = password;
            if (ModelState.IsValid)
            {
                login = await PersonelDAL.Login(loginCredentials);
                return View(login);

            }
            
            return View(login);


        }
    }
}