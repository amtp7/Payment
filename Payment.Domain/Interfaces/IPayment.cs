using System;

using Payments.Domain.Model;

namespace Payments.Domain.Interfaces
{
    public interface IPayment
    {
        public Payment GetPayment(Guid id);
        public int DoPayment(Payment payment);
    }
}
