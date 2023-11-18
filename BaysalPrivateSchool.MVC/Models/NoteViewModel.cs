using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Point { get; set; }
        public int StudentId { get; set; }
        public StudentViewModel Student { get; set; }
        public int TeacherId { get; set; }
        public TeachersWithDepartmentViewModel Teacher { get; set; }
    }
}