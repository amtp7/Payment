
using System;

namespace Payments.Domain.Model
{
    public class Card
    {       
        public long Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int ExpiryYear { get; set; }
        public int ExpiryMonth { get; set; }
        public int Cvv { get; set; }
    }
}
