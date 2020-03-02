using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

using Payments.Domain.Model;
using Payments.Domain.Logic.Interfaces;
using Payments.Domain.DTOs;

namespace Payments.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentLogic _iPaymentLogic;       
               
        public PaymentsController(IPaymentLogic iPaymentLogic)
        {
            _iPaymentLogic = iPaymentLogic;
        }

        [HttpGet]
        public async Task<ActionResult<PaymentHistoryDTO>> GetPaymentHistoryById(long id)
        {
            return await _iPaymentLogic.GetPaymentHistoryById(id);            
        }

        [HttpPost]
        public async Task<ActionResult<string>> SendPayment(float paymentValue, string paymentCurrency, long cardNumber,
            string cardName, int cardExpiryYear, int cardExpiryMonth, int cardCvv)
        {
            return await _iPaymentLogic.SendPayment(
                new Payment
                {
                    Value = paymentValue,
                    Currency = paymentCurrency,
                    CardName = cardName,
                    CardNumber = cardNumber,
                    CardExpiryYear = cardExpiryYear,
                    CardExpiryMonth = cardExpiryMonth,
                    CardCvv = cardCvv
                }
            );
        }
    }
}