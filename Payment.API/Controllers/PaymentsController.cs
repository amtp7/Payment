using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

using Payments.Domain.Model;
using Payments.Domain.ILogic;

namespace Payments.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private IPaymentLogic _iPaymentLogic;

        public PaymentsController(IPaymentLogic iPaymentLogic)
        {
            _iPaymentLogic = iPaymentLogic;
        }

        [HttpGet]
        public async Task<ActionResult<Payment>> GetPaymentHistoryById(Guid id)
        {
            return await _iPaymentLogic.GetPaymentHistoryById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> SendPayment(Guid paymentId, float paymentValue, int paymentCurrency, DateTime paymentDate, int paymentStatus, 
            int cardNumber, string cardName, int cardExpiryYear, int cardExpiryMonth, int cardCvv)
        {
           return await _iPaymentLogic.SendPayment(new Payment { });
        }
    }
}