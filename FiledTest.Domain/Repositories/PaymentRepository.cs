using FiledTest.Domain.Data;
using FiledTest.Domain.Interfaces.Repository;
using FiledTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiledTest.Domain.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly PaymentDbContext _context;

        public PaymentRepository(PaymentDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Payment> UpdatePayment(int id)
        {
            var currentPayment = await _context.Payments.Where(x => x.Id == id)
                              .Include(x => x.PaymentState).FirstOrDefaultAsync();
            var currntPaymentState = _context.PaymentStates.FirstOrDefault(state => state.Title == "processed");
            currentPayment.PaymentState = currntPaymentState;
            currentPayment.PaymentStateId = currntPaymentState.Id;
            _context.Update(currentPayment);
            await _context.SaveChangesAsync();
            return currentPayment;
        }

    }
}
