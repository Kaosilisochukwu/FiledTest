using FiledTest.Domain.DTO;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Api.Examples
{
    public class RequestExamples : IExamplesProvider<RequestPaymentDTO>
    {
        public RequestPaymentDTO GetExamples()
        {
            return new RequestPaymentDTO()
            {
                Amount = 200,
                CardHolder = "John Doe",
                CreditCardNumber = "4111112341141511",
                ExpirationDate = DateTime.Now.AddYears(1),
                SecurityCode = "123"
            };
        }
    }
}
