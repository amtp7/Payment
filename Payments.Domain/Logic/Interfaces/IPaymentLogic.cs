using Payments.Domain.Model;
using System.Threading.Tasks;

namespace Payments.Domain.Logic.Interfaces
{
    public interface IPaymentLogic
    {
        public Task<Payment> GetPaymentHistoryById(long id);
        public Task<int> SendPayment(Payment payment);
    }
}
