using FiledTest.Domain.Models;
using System.Threading.Tasks;

namespace FiledTest.Domain.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<Payment> ProcessPayment(Payment payment);
    }
}
