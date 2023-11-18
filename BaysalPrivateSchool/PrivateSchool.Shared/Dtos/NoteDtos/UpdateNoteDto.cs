using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateSchool.Shared.Dtos.NoteDtos
{
    public class UpdateNoteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Point { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}