using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Shared.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public decimal MonthlyFee { get; set; }
        public string CV { get; set; }
        public Department Department { get; set; }

    }
}