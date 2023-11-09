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
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentManager;

        public DepartmentController(IDepartmentService departmentManager)
        {
            _departmentManager = departmentManager;
        }

        [HttpGet("/getDepartments")]
        public IActionResult GetAll()
        {
            var response = _departmentManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}