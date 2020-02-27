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
        public async Task<ActionResult<Payment>> DoPayment(Guid id, float value, int currency, DateTime date, int status, Card card)
        {
           return await _payment.DoPayment(value, currency, date, status, card);
        }
    }
}
