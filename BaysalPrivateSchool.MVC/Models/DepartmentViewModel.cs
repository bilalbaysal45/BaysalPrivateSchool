using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class DepartmentViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}