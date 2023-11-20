using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class TeacherViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("BirthDate")]
        public DateTime BirthDate { get; set; }
        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("IsDeleted")]
        public bool IsDeleted { get; set; }
        [JsonPropertyName("MonthlyFee")]
        public decimal MonthlyFee { get; set; }
        [JsonPropertyName("CV")]
        public string CV { get; set; }
        [JsonPropertyName("Department")]
        public DepartmentViewModel Department { get; set; }
    }
}