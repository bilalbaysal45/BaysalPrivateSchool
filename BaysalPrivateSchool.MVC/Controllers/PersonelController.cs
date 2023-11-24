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
            Root<bool> login = new Root<bool>();
            var loginCredentials = new LoginViewModel();
            loginCredentials.Email = email;
            loginCredentials.Password = password;
            if (ModelState.IsValid)
            {
                login = await PersonelDAL.Login(loginCredentials);
                if(login.Data)
                {
                    var teacher = await PersonelDAL.GetTeacher(loginCredentials);
                    UserInfo.UserId = teacher.Data.Id;
                    return RedirectToAction("Index","Home",new {area="Personel",id= teacher.Data.Id}); // Personel area'ya yönlendirme
                }
            }
            return View(login);
        }
    }
}