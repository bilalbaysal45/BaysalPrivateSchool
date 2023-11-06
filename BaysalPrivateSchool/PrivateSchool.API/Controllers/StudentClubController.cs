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
    public class StudentClubController : ControllerBase
    {
        private readonly IStudentClubService _studentClubManager;

        public StudentClubController(IStudentClubService studentClubManager)
        {
            _studentClubManager = studentClubManager;
        }
        [HttpGet("/getStudentClubsWithStudentsAndTeachers")]
        public IActionResult GetStudentClubsWithStudentsAndTeachers()
        {
            var response = _studentClubManager.GetStudentClubWithStudentsAndTeachers();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/getStudentClubsWithNews")]
        public IActionResult GetNewsWithStudentClubs()
        {
            var response = _studentClubManager.GetStudentClubsWithNews();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}