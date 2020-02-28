using System;

namespace Payments.Domain.Model
{
    public class Payment
    {
        public Guid Id { get; set; }
        public float Value { get; set; }
        public int Currency { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public Card Card { get; set; }     
    }
}
