using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Models;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Models
{
    public class TeacherWithClassesViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        public List<TeacherClassesViewModel> TeacherClasses { get; set; }
    }
}