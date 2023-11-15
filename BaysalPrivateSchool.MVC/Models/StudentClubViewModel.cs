using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class StudentClubViewModel
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
        [JsonPropertyName("CreatedDate")]
        public virtual DateTime CreatedDate { get; set; }
        [JsonPropertyName("ModifiedDate")]
        public virtual DateTime ModifiedDate { get; set; }
        [JsonPropertyName("Teachers")]
        public List<TeachersWithDepartmentViewModel> Teachers { get; set; }
        [JsonPropertyName("Students")]
        public List<StudentViewModel> Students { get; set; }
        public int? CurrentId { get; set; }
    }
}