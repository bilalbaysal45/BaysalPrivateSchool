using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateSchool.Shared.Dtos
{
    public class SchoolInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string WebUrl { get; set; }
        public string AboutText { get; set; }
        public byte[] AboutImage { get; set; }// deneme
        public string Note { get; set; }
        public decimal Price { get; set; }
    }
}