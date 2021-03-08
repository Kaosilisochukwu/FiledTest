using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Domain.Validations
{
    public class ValidateSecurityCode : ValidationAttribute
    {
        protected override ValidationResult
               IsValid(object value, ValidationContext validationContext)
        {
            if (int.TryParse(value.ToString(), out _) && (value.ToString() == null 
                            || value.ToString().Length == 3 || value.ToString() == string.Empty))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("Security code must either be empty or must be made of digits of 3 characters");
            }
        }
    }
}
