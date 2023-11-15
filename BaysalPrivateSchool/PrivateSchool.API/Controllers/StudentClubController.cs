using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrivateSchool.API.JsonOptions;
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
            var jsonResponse = JsonSerializer.Serialize(response, JsonOptionEndLoop.Option());
            return Ok(jsonResponse);
        }
        [HttpGet("/getStudentClubsWithNews")]
        public IActionResult GetNewsWithStudentClubs()
        {
            // JsonSerializerOptions options = new()
            // {
            //     ReferenceHandler = ReferenceHandler.IgnoreCycles,
            //     WriteIndented = true
            // };

            var response = _studentClubManager.GetStudentClubsWithNews();
            var jsonResponse = JsonSerializer.Serialize(response, JsonOptionEndLoop.Option()); // For IgnoreCycles
            return Ok(jsonResponse);
        }
    }
}