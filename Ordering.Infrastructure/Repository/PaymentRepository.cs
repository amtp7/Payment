using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Payments.Domain.IRepository;
using Payments.Domain.Model;

namespace Payments.Infrastructure.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        public async Task<Payment> GetPaymentHistoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SendPayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
