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
            if (value.ToString() == null || value.ToString().Length == 3)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("Enter a valid security code");
            }
        }
    }
}
