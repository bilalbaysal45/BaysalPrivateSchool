using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateSchool.Shared.Dtos.NewsDtos
{
    public class AddNewsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int StudentClubId { get; set; }
    }
}