using Payments.Domain.DTOs;
using Payments.Domain.Model;
using System.Threading.Tasks;

namespace Payments.Domain.Logic.Interfaces
{
    public interface IPaymentLogic
    {
        public Task<PaymentHistoryDTO> GetPaymentHistoryById(long id);
        public Task<string> SendPayment(Payment payment);
    }
}
