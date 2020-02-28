using Payments.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.IRepository
{
    public interface IPaymentRepository
    {
        public Task<int> SendPayment(Payment payment);

        public Task<Payment> GetPaymentHistoryById(Guid id);
    }
}
