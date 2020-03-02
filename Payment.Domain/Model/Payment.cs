using System;

namespace Payments.Domain.Model
{
    public class Payment
    {
        public long Id { get; set; }
        public float Value { get; set; }
        public int Currency { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public Card Card { get; set; }     
    }
}
