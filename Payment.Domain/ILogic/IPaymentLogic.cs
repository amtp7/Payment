using System;
using System.Threading.Tasks;
using Payments.Domain.Model;

namespace Payments.Domain.ILogic
{
    public interface IPaymentLogic
    {
        public Task<Payment> GetPaymentHistoryById(Guid id);
        public Task<int> SendPayment(Payment payment);
    }
}
