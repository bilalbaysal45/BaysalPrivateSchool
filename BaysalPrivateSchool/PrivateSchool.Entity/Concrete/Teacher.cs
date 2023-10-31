using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Abstract;

namespace PrivateSchool.Entity.Concrete
{
    public class Teacher : BaseEntityPerson
    {
        public decimal MonthlyFee { get; set; }
        public string CV { get; set; }
        // public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}