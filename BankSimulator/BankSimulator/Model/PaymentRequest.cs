﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.Model
{
    public class PaymentRequest
    {
        public float Value { get; set; }
        public string Currency { get; set; }
        public long CardNumber { get; set; }
        public string CardName { get; set; }
        public int CardExpiryYear { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardCvv { get; set; }
    }
}
