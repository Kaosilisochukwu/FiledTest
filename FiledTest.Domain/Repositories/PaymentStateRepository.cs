using FiledTest.Domain.Data;
using FiledTest.Domain.Interfaces.Repository;
using FiledTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiledTest.Domain.Repositories
{
    public class PaymentStateRepository : BaseRepository<PaymentState>, IPaymentStateRepository
    {
        public PaymentStateRepository(PaymentDbContext context) : base(context) { }
    }
}
