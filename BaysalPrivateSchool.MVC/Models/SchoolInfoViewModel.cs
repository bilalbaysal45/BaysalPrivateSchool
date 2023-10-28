using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class SchoolInfoViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Phone")]
        public string Phone { get; set; }
        [JsonPropertyName("Mail")]
        public string Mail { get; set; }
        [JsonPropertyName("WebUrl")]
        public string WebUrl { get; set; }
        [JsonPropertyName("AboutText")]
        public string AboutText { get; set; }
        [JsonPropertyName("AboutImage")]
        public byte[] AboutImage { get; set; }// deneme
        [JsonPropertyName("Note")]
        public string Note { get; set; }
        [JsonPropertyName("Price")]
        public decimal Price { get; set; }
    }
}