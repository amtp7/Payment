
namespace Payments.Domain.Model
{
    public class Card
    {       
        public int Number { get; set; }
        public string Name { get; set; }
        public int ExpiryYear { get; set; }
        public int ExpiryMonth { get; set; }
        public int Cvv { get; set; }
    }
}
