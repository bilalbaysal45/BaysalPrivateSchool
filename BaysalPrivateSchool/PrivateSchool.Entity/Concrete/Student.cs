using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Abstract;

namespace PrivateSchool.Entity.Concrete
{
    public class Student : BaseEntity
    {
        public string _studentNumber;
        public string StudentNumber
        {
            get
            {
                return $"{CreatedDate}0{Id}";
            }
        }
        public int RightOfAbsence { get; set; } = 30;
    }
}