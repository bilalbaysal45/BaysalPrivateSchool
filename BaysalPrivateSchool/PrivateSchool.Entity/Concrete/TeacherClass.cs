using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateSchool.Entity.Concrete
{
    public class TeacherClass
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SClassId { get; set; }
        public SClass SClass { get; set; }
    }
}