using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payments.Infrastructure.EFModel
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public float Value { get; set; }
        public int Currency { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public long CardNumber { get; set; }
        public string CardName { get; set; }
        public int CardExpiryYear { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardCvv { get; set; }
    }
}
