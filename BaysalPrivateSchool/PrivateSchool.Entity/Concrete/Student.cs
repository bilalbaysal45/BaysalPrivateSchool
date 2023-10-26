using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Abstract;

namespace PrivateSchool.Entity.Concrete
{
    public class Student : BaseEntity
    {
        public string StudentNumber
        {
            get
            {
                return $"{DateTime.Now.Year}{Id}";
            }
        }
        public int RightOfAbsence { get; set; } = 30;
    }
}