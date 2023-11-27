using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class UpdateNoteViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        [Required(ErrorMessage ="Midterm or Final")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        [Required(ErrorMessage = "Please Enter Your Department(Matematik,Türkce,Biyoloji etc...)")]
        public string Description { get; set; }
        [JsonPropertyName("Point")]
        [Required(ErrorMessage = "Please Enter Score")]
        [Range(-1,100,ErrorMessage ="Enter Score between -1 and 100")]
        public float Point { get; set; }
        [JsonPropertyName("StudentId")]
        public int StudentId { get; set; }
        [JsonPropertyName("TeacherId")]
        public int TeacherId { get; set; }
    }
}