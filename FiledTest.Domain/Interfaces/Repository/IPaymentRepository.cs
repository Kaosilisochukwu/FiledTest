using FiledTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiledTest.Domain.Interfaces.Repository
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        Task<Payment> UpdatePayment(int id);
    }
}
