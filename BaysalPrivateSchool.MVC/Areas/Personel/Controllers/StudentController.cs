using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Personel.Models;
using BaysalPrivateSchool.MVC.Areas.Student.Models.User;
using BaysalPrivateSchool.MVC.Data;
using BaysalPrivateSchool.MVC.Data.CheckProperties;
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
                var students = await StudentDAL.GetAll();
                return RedirectToAction("Index", students);

            }
            return View(addStudent);
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
                return RedirectToAction("Index");
            }
            return View(updateStudent);
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
            if (await CheckDepartment.IsValid(updateNote.Description) && await CheckNote.IsValid(updateNote.Name) && ModelState.IsValid)
            {
                updateNote.StudentId = UserInfo.StudentIdForNote;
                updateNote.TeacherId = UserInfo.UserId;
                await NoteDAL.Update(updateNote);
                return RedirectToAction("Notes");
            }
            return View(updateNote);
        }
        [HttpGet]
        public async Task<IActionResult> NoteAdd(int id)
        {
            UserInfo.StudentIdForNote = id;
            var teacherWithDepartment = await PersonelDAL.GetTeachersWithDepartment();
            ViewBag.Department = new TeachersWithDepartmentViewModel();
            ViewBag.Department = teacherWithDepartment.Data.Find(x=>x.Id == UserInfo.UserId);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NoteAdd(AddNoteViewModel addNote)
        {
            if (ModelState.IsValid && await CheckNote.IsValid(addNote.Name))
            {
                addNote.StudentId = UserInfo.StudentIdForNote;
                addNote.TeacherId = UserInfo.UserId;
                await NoteDAL.Create(addNote);
                return RedirectToAction("Notes");
            }
            var teacherWithDepartment = await PersonelDAL.GetTeachersWithDepartment();
            ViewBag.Department = new TeachersWithDepartmentViewModel();
            ViewBag.Department = teacherWithDepartment.Data.Find(x => x.Id == UserInfo.UserId);
            return View(addNote);
        }
    }
}