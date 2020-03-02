using Payments.Domain.Model;
using Payments.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.DTOs
{
    public class PaymentHistoryDTO : IPaymentHistoryDTO
    {
        public float Value { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public int CardExpiryYear { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardCvv { get; set; }

        private readonly IStatus _iStatus;

        public PaymentHistoryDTO()
        {
            _iStatus = new Status();
        }

        public PaymentHistoryDTO MapToPaymentHistoryDTO(Payment payment)
        {
            return new PaymentHistoryDTO
            {
                Value = payment.Value,
                Currency = payment.Currency,
                Status = _iStatus.GetStatusMessage(payment.Status),
                CardName = payment.CardName,
                CardNumber = MaskCardNumber(payment.CardNumber),
                CardExpiryYear = payment.CardExpiryYear,
                CardExpiryMonth = payment.CardExpiryMonth,
                CardCvv = payment.CardCvv
            };
        }

        private string MaskCardNumber(long cardNumber)
        {
            string tempCard = cardNumber.ToString();
            string resultCard = "";

            for (int i = 0; i < tempCard.Length; i++)
            {
                if (i < 2)
                    resultCard += "X";

                else if (i > tempCard.Length - 5)
                    resultCard += "X";

                else
                    resultCard += tempCard[i];
            }

            return resultCard;
        }
    }
}
