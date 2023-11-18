using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PrivateSchool.Entity.Abstract;

namespace PrivateSchool.Entity.Concrete
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        [NotMapped]
        public List<StudentClubsNews> StudentClubsNews { get; set; }
    }
}