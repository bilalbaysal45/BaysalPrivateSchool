using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Models.NewsModel
{
    public class UpdateNewsViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }
        [JsonPropertyName("Title")]
        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }
        [JsonPropertyName("StudentClubId")]
        public int StudentClubId { get; set; }
    }
}