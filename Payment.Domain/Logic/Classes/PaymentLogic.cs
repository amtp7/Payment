using Payments.Domain.IRepository;
using Payments.Domain.Logic.Interfaces;
using Payments.Domain.Model;
using System;
using System.Threading.Tasks;

namespace Payments.Domain.Logic.Classes
{
    public class PaymentLogic : IPaymentLogic
    {
        private IPaymentRepository _iPaymentRepository;

        public PaymentLogic(IPaymentRepository iPaymentRepository)
        {
            _iPaymentRepository = iPaymentRepository;
        }

        public async Task<Payment> GetPaymentHistoryById(long id)
        {
            return await _iPaymentRepository.GetPayment(id);
        }

        public Task<int> SendPayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
