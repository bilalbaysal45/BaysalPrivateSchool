using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrivateSchool.Business.Abstract;

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
        [HttpGet("/getTeachersWithDepartment")]
        public IActionResult GetTeachersWithDepartment()
        {
            var response = _teacherManager.GetTeachersWithDepartment();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}