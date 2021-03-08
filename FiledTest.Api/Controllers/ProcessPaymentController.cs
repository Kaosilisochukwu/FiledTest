using AutoMapper;
using FiledTest.Domain.DTO;
using FiledTest.Domain.Interfaces.Services;
using FiledTest.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseModel))]
        public async Task<IActionResult> ProcessPaymentController(RequestPaymentDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var payment = _mapper.Map<Payment>(model);
                    var response = await _paymentService.ProcessPayment(payment);
                    if (response.PaymentState.Title == "failed")
                        return BadRequest(new ResponseModel(400, "Process failed", response));
                    return Ok(new ResponseModel(200, "success", response));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new ResponseModel(500, ex.Message, model));
                }
            }
            var errors = ModelState.Values.SelectMany(error => error.Errors).Select(err => err.ErrorMessage);
            return BadRequest(new ResponseModel(400, "There are some validation errors", errors));
        }

    }
}
