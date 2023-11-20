using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class TeacherClassesViewModel
    {
        public int TeacherId { get; set; }
        public int SClassId { get; set; }
        public TeacherViewModel Teacher { get; set; }
        public SClassViewModel SClass { get; set; }

    }
}