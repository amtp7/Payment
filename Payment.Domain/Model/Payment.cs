using System;
using Payments.Domain.Interfaces;

namespace Payments.Domain.Model
{
    public class Payment : IPayment
    {
        public Guid Id { get; set; }
        public float Value { get; set; }
        public int Currency { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public Card Card { get; set; }     
        
        public Payment(Guid id, float value, int currency, 
            DateTime date, int status, Card card)
        {

        }
        public Payment GetPayment(Guid id)
        {

        }

        public int DoPayment(Payment payment)
        {

        }
    }
}
