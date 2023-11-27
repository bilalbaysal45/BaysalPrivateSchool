using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Models
{
    public class UpdateTeacherViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("FirstName")]
        [Required(ErrorMessage = "Please Enter Your FirstName")]
        [MinLength(2,ErrorMessage = "Please Enter At Least 2 Character")]
        [MaxLength(20,ErrorMessage = "Please Enter 20 Character At Most")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        [Required(ErrorMessage = "Please Enter Your LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Email")]
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }
        [JsonPropertyName("Password")]
        [Required(ErrorMessage = "Required"),MinLength(8,ErrorMessage = "Please Enter At Least 8 Character")]
        public string Password { get; set; }
        [JsonPropertyName("BirthDate")]
        public DateTime BirthDate { get; set; }
        [JsonPropertyName("MonthlyFee")]
        [Required(ErrorMessage = "Please Enter Fee")]
        public decimal MonthlyFee { get; set; }
        [JsonPropertyName("CV")]
        [DisplayName("CV Summary")]
        [Required(ErrorMessage = "Please Enter Your CV")]
        public string CV { get; set; }
    }
}