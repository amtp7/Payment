using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

using Payments.Domain.Interfaces;
using Payments.Domain.Model;

namespace Payments.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private IPayment _payment;

        public PaymentsController(Payment payment)
        {
            _payment = payment;
        }

        [HttpGet]
        public async Task<ActionResult<Payment>> GetPayment(Guid id)
        {
            return await _payment.GetPayment(id);
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> DoPayment(Payment payment)
        {
           return await _payment.DoPayment(payment);
        }
    }
}
