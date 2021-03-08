using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Domain.Validations
{
    public class ValidateCreditCardNumber : ValidationAttribute
    {
        protected override ValidationResult
               IsValid(object value, ValidationContext validationContext)
        {
            bool creditCardInputAreAllNumbers = long.TryParse(value.ToString(), out long result);
            if (creditCardInputAreAllNumbers && value.ToString().Length == 16)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("Credit card number length must be equal to 16 and must contain only digits");
            }
        }
    }
}
