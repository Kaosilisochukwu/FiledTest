using FiledTest.Domain.Data;
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
        private readonly PaymentDbContext _context;

        public PaymentService(PaymentDbContext context)
        {
            var paymentRepository = new PaymentRepository(context);
            _cheapPaymentGateway = new CheapPaymentService(paymentRepository);
            _expensivePaymentGateway = new ExpensivePaymentService(paymentRepository);
            _premiumPaymentGateway = new PremiumPaymentService(paymentRepository);
            _context = context;
        }
        public async Task<Payment> ProcessPayment(Payment payment)
        {
            payment.PaymentState = _context.PaymentStates.FirstOrDefault(state => state.Title == "pending");
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
                payment.PaymentState = _context.PaymentStates.FirstOrDefault(state => state.Title == "failed");
                return payment;
            }
        }
    }
}
