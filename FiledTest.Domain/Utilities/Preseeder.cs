using FiledTest.Domain.Data;
using FiledTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiledTest.Domain.Utilities
{
    public class Preseeder
    {
       
        public async static Task SeederPaymentState(PaymentDbContext context)
        {
            context.Database.EnsureCreated();
            var paymentStates = new List<PaymentState>
            {
                new PaymentState
                {
                    Id = 1,
                    Title = "pending",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                },
                new PaymentState
                {
                    Id = 2,
                    Title = "processed",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                },
                new PaymentState
                {
                    Id = 3,
                    Title = "failed",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                }
            };
            if(!context.PaymentStates.Any())
                await context.PaymentStates.AddRangeAsync(paymentStates);
            await context.SaveChangesAsync();
        }
    }
}
