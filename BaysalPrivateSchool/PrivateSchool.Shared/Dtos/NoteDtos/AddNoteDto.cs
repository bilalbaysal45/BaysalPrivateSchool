using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateSchool.Shared.Dtos.NoteDtos
{
    public class AddNoteDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Point { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}