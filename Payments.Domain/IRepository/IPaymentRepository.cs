using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payments.Domain.Model;

namespace Payments.Domain.IRepository
{
    public interface IPaymentRepository
    {
        //List<Payment> GetAllPayments();

        Task<Payment> GetPayment(long id);
        void AddPayment(Payment payment);

        //void UpdatePayment(Payment dbPayment, Payment payment);
        //void DeletePayment(Payment payment);
    }
}
