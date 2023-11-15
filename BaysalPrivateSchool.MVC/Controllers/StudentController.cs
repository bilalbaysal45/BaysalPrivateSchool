using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Student.Models.User;
using BaysalPrivateSchool.MVC.Data;
using BaysalPrivateSchool.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            bool login = false;
            var loginCredentials = new LoginViewModel();
            loginCredentials.Email = email;
            loginCredentials.Password = password;
            if (ModelState.IsValid)
            {
                login = await StudentDAL.Login(loginCredentials);
                if (login)
                {
                    var student = await StudentDAL.GetStudent(loginCredentials);
                    UserInfo.UserId = student.Id;
                    return RedirectToAction("Index", "Student", new { area = "Student",student.Id}); // Personel area'ya yönlendirme
                }
            }
            return View(login);
        }
    }
}