using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiledTest.Domain.Models
{
    public class PaymentState
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = "pending";
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
