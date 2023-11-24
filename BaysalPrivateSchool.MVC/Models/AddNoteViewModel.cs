using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class AddNoteViewModel
    {
        [JsonPropertyName("Name")]
        [DisplayName("Name : ")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("Point")]
        public float Point { get; set; }
        [JsonPropertyName("StudentId")]
        public int StudentId { get; set; }
        [JsonPropertyName("TeacherId")]
        public int TeacherId { get; set; }
    }
}