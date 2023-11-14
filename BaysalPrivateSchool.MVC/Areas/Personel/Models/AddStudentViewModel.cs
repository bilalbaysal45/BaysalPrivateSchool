using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Models
{
    public class AddStudentViewModel
    {
        [JsonPropertyName("Firstname")]
        public string FirstName { get; set; }
        [JsonPropertyName("Lastname")]
        public string LastName { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        [JsonPropertyName("BirthDate")]
        public DateTime BirthDate { get; set; }
    }
}