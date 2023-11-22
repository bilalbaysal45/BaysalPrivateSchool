using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Personel.Models;
using BaysalPrivateSchool.MVC.Areas.Student.Models.User;
using BaysalPrivateSchool.MVC.Data;
using BaysalPrivateSchool.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class StudentController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await StudentDAL.GetAll();
            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddStudentViewModel addStudent)
        {
            if (ModelState.IsValid)
            {
                var response = await StudentDAL.Create(addStudent);
                return View();
            }
            var students = await StudentDAL.GetAll();
            return RedirectToAction("Index", students);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await StudentDAL.GetById(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateStudentViewModel updateStudent)
        {
            if (ModelState.IsValid)
            {
                var response = await StudentDAL.Update(updateStudent);
                // ViewBag.Success = "Success";
                return RedirectToAction("Update", response.Id);
            }
            // ViewBag.Error = "Error";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await StudentDAL.Delete(id);

            var students = await StudentDAL.GetAll();
            return RedirectToAction("Index", "Student", students);
        }
        [HttpGet]
        public async Task<IActionResult> Notes()
        {
            var teacher = await PersonelDAL.GetTeacherWithClass(UserInfo.UserId);
            return View(teacher);
        }
        [HttpGet]
        public async Task<IActionResult> NoteUpdate(int id)
        {
            var response = await NoteDAL.GeyById(id);
            UserInfo.StudentIdForNote = response.StudentId;
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> NoteUpdate(UpdateNoteViewModel updateNote)
        {
            updateNote.StudentId = UserInfo.StudentIdForNote;
            updateNote.TeacherId = UserInfo.UserId;
            await NoteDAL.Update(updateNote);
            return RedirectToAction("Notes");
        }
        [HttpGet]
        public async Task<IActionResult> NoteAdd(int id)
        {
            UserInfo.StudentIdForNote = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NoteAdd(AddNoteViewModel addNote)
        {
            addNote.StudentId = UserInfo.StudentIdForNote;
            addNote.TeacherId = UserInfo.UserId;
            await NoteDAL.Create(addNote);
            return RedirectToAction("Notes");
        }
    }
}