using System;
using System.Threading.Tasks;
using Payments.Domain.ILogic;
using Payments.Domain.IRepository;
using Payments.Domain.Model;

namespace Payments.Domain.Logic
{
    public class PaymentLogic : IPaymentLogic
    {
        private IPaymentRepository _iPaymentRepository;

        public PaymentLogic(IPaymentRepository iPaymentRepository)
        {
            _iPaymentRepository = iPaymentRepository;
        }

        public async Task<Payment> GetPaymentHistoryById(Guid id)
        {
            return await _iPaymentRepository.GetPaymentHistoryById(id);
        }

        public async Task<int> SendPayment(Payment payment)
        {
            return await _iPaymentRepository.SendPayment(payment);
        }
    }
}
