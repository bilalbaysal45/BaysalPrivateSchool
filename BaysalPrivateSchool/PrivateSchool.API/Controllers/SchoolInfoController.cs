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
    public class SchoolInfoController : ControllerBase
    {
        private readonly ISchoolInfoService _schoolInfoManager;
        public SchoolInfoController(ISchoolInfoService schoolInfoManager)
        {
            _schoolInfoManager = schoolInfoManager;
        }
        [HttpGet("/getSchoolInfos")]
        public IActionResult GetAll()
        {
            var response = _schoolInfoManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}