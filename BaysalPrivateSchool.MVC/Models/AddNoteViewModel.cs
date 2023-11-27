using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class AddNoteViewModel
    {
        [JsonPropertyName("Name")]
        [Required(ErrorMessage = "Midterm or Final")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        [Required(ErrorMessage = "Please Type Department(Matematik,Biyoloji etc...)")]
        public string Description { get; set; }
        [JsonPropertyName("Point")]
        [Required(ErrorMessage = "Please Enter Score")]
        [Range(-1,100)]
        public float Point { get; set; }
        [JsonPropertyName("StudentId")]
        public int StudentId { get; set; }
        [JsonPropertyName("TeacherId")]
        public int TeacherId { get; set; }
    }
}