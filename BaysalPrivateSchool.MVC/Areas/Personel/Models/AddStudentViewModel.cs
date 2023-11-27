using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.Areas.Personel.Models
{
    public class AddStudentViewModel
    {
        [JsonPropertyName("Firstname")]
        [Required(ErrorMessage = "Please Enter Your FirstName")]
        [MinLength(2, ErrorMessage = "Please Enter At Least 2 Character")]
        [MaxLength(20, ErrorMessage = "Please Enter 20 Character At Most")]
        public string FirstName { get; set; }
        [JsonPropertyName("Lastname")]
        [Required(ErrorMessage = "Please Enter Your LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Email")]
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }
        [JsonPropertyName("Password")]
        [Required(ErrorMessage = "Required"), MinLength(8, ErrorMessage = "Please Enter At Least 8 Character")]
        public string Password { get; set; }
        [JsonPropertyName("BirthDate")]
        [Required(ErrorMessage = "Please Enter Your BirthDate")]
        public DateTime BirthDate { get; set; }
    }
}