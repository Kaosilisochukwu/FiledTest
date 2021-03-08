using FiledTest.Domain.Data;
using FiledTest.Domain.Models;
using FiledTest.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FiledTest.UnitTest
{
    public class UnitTest1
    {
        private PaymentDbContext _context;
        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<PaymentDbContext>()
                            .UseInMemoryDatabase(databaseName: "MovieListDatabase")
                            .Options;
            var context = new PaymentDbContext(options);

            context.PaymentStates.AddRange(paymentStates);
            context.SaveChanges();
            _context = context;
        }

        [Fact]
        public async Task ProcessPayment_ShouldSuccessfullyProcessPremiumPayment()
        {

            //Arrange

            var payment = new Payment()
            {
                Amount = 2000,
                CardHolder = "John Doe",
                CreditCardNumber = "4111112341141511",
                ExpirationDate = DateTime.Now.AddYears(1),
                SecurityCode = "123"

            };
            var paymentService = new PaymentService(_context);


            //Act
            var response = await paymentService.ProcessPayment(payment);

            //Assert
            Assert.Equal("processed", response.PaymentState.Title);
            Assert.Equal(2, response.PaymentState.Id);
            Assert.Same(typeof(Payment), response.GetType());
        }



        public List<PaymentState> paymentStates = new List<PaymentState>
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
    }
}
