using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Abstract;

namespace PrivateSchool.Entity.Concrete
{
    public class StudentClub : BaseEntity
    {
        // public int StudentId { get; set; }
        // public int TeacherId { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public List<StudentClubsNews> StudentClubsNews { get; set; }
    }
}