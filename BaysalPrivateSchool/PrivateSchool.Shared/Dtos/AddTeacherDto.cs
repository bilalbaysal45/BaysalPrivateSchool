using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Concrete;

namespace PrivateSchool.Shared.Dtos
{
    public class AddTeacherDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal MonthlyFee { get; set; }
        public string CV { get; set; }
        public int DepartmentId { get; set; }

    }
}