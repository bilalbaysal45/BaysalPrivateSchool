using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Shared.Dtos.NoteDtos;

namespace PrivateSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteManager;

        public NoteController(INoteService noteManager)
        {
            _noteManager = noteManager;
        }
        [HttpGet("/getNotes")]
        public IActionResult GetAll()
        {
            var response = _noteManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/getNote/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _noteManager.GetById(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/addNote")]
        public IActionResult Create(AddNoteDto addNote)
        {
            var response = _noteManager.Create(addNote);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPut("/updateNote")]
        public IActionResult Update(UpdateNoteDto updateNote)
        {
            var response = _noteManager.Update(updateNote);
            var JsonResponse = JsonSerializer.Serialize(response);
            return Ok(JsonResponse);
        }
    }
}