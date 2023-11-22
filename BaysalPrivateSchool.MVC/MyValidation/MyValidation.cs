using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaysalPrivateSchool.MVC.MyValidation
{
    public class MyValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = string.Empty;
            if(value is string)
            {
                name = (string)value;
                if(name != "Midterm" || name != "Final")
                {
                    return new ValidationResult("Write Midterm or Final");
                }
            }
            return ValidationResult.Success;
        }
    }
}