using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

using Payments.Domain.Model;
using Payments.Domain.Logic.Interfaces;

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
        public async Task<ActionResult<Payment>> GetPaymentHistoryById(long id)
        {
            return await _iPaymentLogic.GetPaymentHistoryById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> SendPayment(long paymentId, float paymentValue, int paymentCurrency, DateTime paymentDate, int paymentStatus,
            long cardId, int cardNumber, string cardName, int cardExpiryYear, int cardExpiryMonth, int cardCvv)
        {
            return await _iPaymentLogic.SendPayment(
                new Payment
                {
                    Id = paymentId,
                    Value = paymentValue,
                    Currency = paymentCurrency,
                    Date = paymentDate,
                    Status = paymentStatus,
                    Card = new Card
                    {
                        Id = cardId,
                        Name = cardName,
                        Number = cardNumber,
                        ExpiryYear = cardExpiryYear,
                        ExpiryMonth = cardExpiryMonth,
                        Cvv = cardCvv
                    }
                }
            );
        }
    }
}