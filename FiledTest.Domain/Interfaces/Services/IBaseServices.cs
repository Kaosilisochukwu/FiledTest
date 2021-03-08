using FiledTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiledTest.Domain.Interfaces.Services
{
    public interface IBaseServices
    {
        Task<int> ProcessPayment(Payment model);
        Task<Payment> UpdatePayment(int id);
    }
}
