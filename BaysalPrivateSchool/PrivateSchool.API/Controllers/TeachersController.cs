using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Shared.Dtos;

namespace PrivateSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherManager;
        public TeachersController(ITeacherService teacherManager)
        {
            _teacherManager = teacherManager;
        }
        [HttpGet("/getTeachers")]
        public IActionResult GetAll()
        {
            var response = _teacherManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/getTeacher/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _teacherManager.GetById(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/addTeacher")]
        public IActionResult Create(AddTeacherDto addTeacherDto)
        {
            var response = _teacherManager.Create(addTeacherDto);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPut("/updateTeacher")]
        public IActionResult Update(UpdateTeacherDto updateTeacher)
        {
            var response = _teacherManager.Update(updateTeacher);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpDelete("/deleteTeacher/{id}")]
        public IActionResult Delete(int id)
        {
            _teacherManager.Delete(id);
            var response = _teacherManager.GetById(id);
            if (response == null)
            {
                var jsonResponse = JsonSerializer.Serialize(true);
                return Ok(jsonResponse);
            }
            return Ok(JsonSerializer.Serialize(false));
        }
        [HttpGet("/getTeachersWithDepartment")]
        public IActionResult GetTeachersWithDepartment()
        {
            var response = _teacherManager.GetTeachersWithDepartment();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var login = _teacherManager.Login(loginDto);
            var jsonResponse = JsonSerializer.Serialize(login);

            return Ok(jsonResponse);
        }
    }
}