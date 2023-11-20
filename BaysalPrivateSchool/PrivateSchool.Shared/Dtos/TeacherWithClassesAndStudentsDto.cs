using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Shared.Dtos
{
    public class TeacherWithClassesAndStudentsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TeacherClass> TeacherClasses { get; set; }
    }
}