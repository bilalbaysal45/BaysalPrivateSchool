using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Abstract;

namespace PrivateSchool.Entity.Concrete
{
    public class Note : BaseEntity
    {
        public float Point { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}