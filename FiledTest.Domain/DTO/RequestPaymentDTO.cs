using FiledTest.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiledTest.Domain.DTO
{
    public class RequestPaymentDTO
    {
        [Required]
        [StringLength(16, MinimumLength = 16)]
        [ValidateCreditCardNumber]
        public string CreditCardNumber { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string CardHolder { get; set; }
        [Required]
        [ValidateExpiryDate]
        public DateTime ExpirationDate { get; set; }
        [ValidateSecurityCode]
        public string SecurityCode { get; set; }
        [Required]
        [ValidateAmount]
        public int Amount { get; set; }
    }
}
