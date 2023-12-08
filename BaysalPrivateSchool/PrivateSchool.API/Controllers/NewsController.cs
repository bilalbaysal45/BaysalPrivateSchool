using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrivateSchool.API.JsonOptions;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Shared.Dtos.NewsDtos;

namespace PrivateSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsManager;

        public NewsController(INewsService newsManager)
        {
            _newsManager = newsManager;
        }

        [HttpGet("/getNews/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _newsManager.GetById(id);
            var jsonResponse = JsonSerializer.Serialize(response,JsonOptionEndLoop.Option());
            return Ok(jsonResponse);
        }
        [HttpPost("/addNews")]
        public IActionResult Create(AddNewsDto addNews)
        {
            var response = _newsManager.Create(addNews);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPut("/updateNews")]
        public IActionResult Update(UpdateNewsDto updateNews)
        {
            var response = _newsManager.Update(updateNews);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}