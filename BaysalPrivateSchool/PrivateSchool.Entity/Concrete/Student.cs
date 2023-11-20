using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Abstract;

namespace PrivateSchool.Entity.Concrete
{
    public class Student : BaseEntityPerson
    {
        public string _studentNumber;
        public string StudentNumber
        {
            get
            {
                return $"{CreatedDate.Year}0{Id}";
            }
        }
        public int RightOfAbsence { get; set; } = 30;
        public int? SClassId { get; set; }
        public SClass SClass { get; set; }
        public int? StudentClubId { get; set; }
        public StudentClub StudentClub { get; set; }
        public List<Note> Notes { get; set; }
    }
}