using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateSchool.Entity.Concrete
{
    public class StudentClubsNews
    {
        public int StudentClubId { get; set; }
        public StudentClub StudentClub { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}