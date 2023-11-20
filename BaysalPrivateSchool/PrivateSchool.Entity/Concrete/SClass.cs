using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Abstract;

namespace PrivateSchool.Entity.Concrete
{
    public class SClass : BaseEntity
    {
        public List<Student> Students { get; set; }
        public List<TeacherClass> TeacherClasses { get; set; }
    }
}