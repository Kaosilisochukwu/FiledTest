using FiledTest.Domain.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace FiledTest.Domain.Models
{
    public class Payment : RequestPaymentDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PaymentStateId { get; set; }
        public PaymentState PaymentState { get; set; }
    }
}
