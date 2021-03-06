using FiledTest.Domain.Data;
using FiledTest.Domain.Interfaces.Repository;
using FiledTest.Domain.Interfaces.Services;
using FiledTest.Domain.Models;
using FiledTest.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPaymentGateway _premiumPaymentGateway;
        private readonly IPaymentStateRepository _paymentStateRepo;

        public PaymentService(ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway,
                                IPremiumPaymentGateway premiumPaymentGateway, IPaymentStateRepository paymentStateRepo)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentGateway = premiumPaymentGateway;
            _paymentStateRepo = paymentStateRepo;
        }
        public async Task<Payment> ProcessPayment(Payment payment)
        {
            payment.PaymentState = await _paymentStateRepo.GetData(1);
            if(payment.Amount < 20)
            {
                var men = await _cheapPaymentGateway.ProcessPayment(payment);
                return await _cheapPaymentGateway.UpdatePayment(payment.Id);
            }
            else if(payment.Amount >= 21 && payment.Amount <= 500)
            {
                if (_expensivePaymentGateway is not null)
                {
                    await _expensivePaymentGateway.ProcessPayment(payment);
                    return await _expensivePaymentGateway.UpdatePayment(payment.Id);                   
                }
                await _cheapPaymentGateway.ProcessPayment(payment);
                return await _cheapPaymentGateway.UpdatePayment(payment.Id);
            }
            else
            {
                var numberOfTrials = 0;
                while (numberOfTrials < 3)
                {
                    await _premiumPaymentGateway.ProcessPayment(payment);
                    var paymentData = await _premiumPaymentGateway.UpdatePayment(payment.Id);
                    if (payment.PaymentState.Title == "processed")
                    {
                        return paymentData;
                    }
                    numberOfTrials += 1;
                }
                payment.PaymentState = await _paymentStateRepo.GetData(3);
                return payment;
            }
        }
    }
}
