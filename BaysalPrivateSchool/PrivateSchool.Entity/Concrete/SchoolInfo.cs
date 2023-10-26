using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateSchool.Entity.Concrete
{
    public class SchoolInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string WebUrl { get; set; }
        public string About { get; set; }
        public string Note { get; set; }
        public decimal Price { get; set; }

    }
}