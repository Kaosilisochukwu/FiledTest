using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Domain.Validations
{
    public class ValidateExpiryDate : ValidationAttribute
    {
         protected override ValidationResult 
                IsValid(object value, ValidationContext validationContext)
        {   
            DateTime _expiryDate = DateTime.Parse(value.ToString()); 
            if (_expiryDate <= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("Date can not be in the past");
            }
        } 
    }
}
