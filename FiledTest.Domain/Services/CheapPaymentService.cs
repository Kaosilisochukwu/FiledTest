using FiledTest.Domain.Interfaces.Repository;
using FiledTest.Domain.Interfaces.Services;
using FiledTest.Domain.Models;
using System.Threading.Tasks;

namespace FiledTest.Domain.Services
{
    public class CheapPaymentService : ICheapPaymentGateway
    {
        private readonly IPaymentRepository _paymentRepository;

        public CheapPaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<int> ProcessPayment(Payment payment)
        {
            return await _paymentRepository.SaveData(payment);
        }

        public async Task<Payment> UpdatePayment(int id)
        {
            var payment = await _paymentRepository.UpdatePayment(id);
            return payment;
        }
    }
}
