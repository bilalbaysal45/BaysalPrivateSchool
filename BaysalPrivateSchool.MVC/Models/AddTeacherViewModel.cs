using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Models
{
    public class AddTeacherViewModel
    {
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        [JsonPropertyName("BirthDate")]
        public DateTime BirthDate { get; set; }
        [JsonPropertyName("MonthlyFee")]
        public decimal MonthlyFee { get; set; }
        [JsonPropertyName("CV")]
        [DisplayName("CV")]
        public string CV { get; set; }
        
        [JsonPropertyName("Department")]
        public DepartmentViewModel Department { get; set; }
    }
}