using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class StudentViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Firstname")]
        public string FirstName { get; set; }
        [JsonPropertyName("Lastname")]
        public string LastName { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("StudentNumber")]
        public string StudentNumber { get; set; }
        [JsonPropertyName("BirthDate")]
        public DateTime Birthdate { get; set; }
        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("IsDeleted")]
        public bool IsDeleted { get; set; }
        [JsonPropertyName("Notes")]
        public List<NoteViewModel> Notes { get; set; }

    }
}