using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Shared.Dtos;
using PrivateSchool.Shared.Dtos.StudentDtos;

namespace PrivateSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentManager;

        public StudentController(IStudentService studentManager)
        {
            _studentManager = studentManager;
        }
        [HttpGet("/getStudents")]
        public IActionResult GetAll()
        {
            var response = _studentManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/getStudent/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _studentManager.GetById(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/addStudent")]
        public IActionResult Create(AddStudentDto addStudent)
        {
            var response = _studentManager.Create(addStudent);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPut("/updateStudent")]
        public IActionResult Update(UpdateStudentDto updateStudent)
        {
            var response = _studentManager.Update(updateStudent);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpDelete("/deleteStudent/{id}")]
        public IActionResult Delete(int id)
        {
            _studentManager.Delete(id);
            var response = _studentManager.GetById(id);
            string jsonResponse = string.Empty;
            if (response.Data == null)
            {
                jsonResponse = JsonSerializer.Serialize(true);
                return Ok(jsonResponse);
            }
            jsonResponse = JsonSerializer.Serialize(false);
            return Ok(jsonResponse);
        }
        [HttpPost("/loginStudent")]
        public IActionResult Login(LoginDto loginDto)
        {
            var login = _studentManager.Login(loginDto);
            var jsonResponse = JsonSerializer.Serialize(login);

            return Ok(jsonResponse);
        }
        [HttpPost("/getStudentLoginCredentials")]
        public IActionResult GetStudentWithLoginCredentials(LoginDto loginDto)
        {
            var response = _studentManager.GetStudentWithLoginCredentials(loginDto);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/changeStudentClub")]
        public IActionResult ChangeStudentClub(ChangeStudentClubDto changeStudentClub)
        {
            var response = _studentManager.ChangeStudentClub(changeStudentClub);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}