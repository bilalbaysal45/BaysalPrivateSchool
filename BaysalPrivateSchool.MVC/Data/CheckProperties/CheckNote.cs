using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Areas.Student.Models.User;

namespace BaysalPrivateSchool.MVC.Data.CheckProperties
{
    public static class CheckNote
    {
        public static async Task<bool> IsValid(string noteName)
        {
            var isValid = await IsExist(noteName);
            if (!isValid && noteName == "Final" || noteName == "Midterm")
            {
                return true;
            }
            return false;

        }
        private static async Task<bool> IsExist(string noteName)
        {
            var notes = await NoteDAL.GetAll();
            var responseNotes = notes.Data.FindAll(n => n.TeacherId == UserInfo.UserId && n.StudentId == UserInfo.StudentIdForNote);
            return responseNotes.Find(x => x.Name == noteName) != null ? true : false;
        }
    }

}