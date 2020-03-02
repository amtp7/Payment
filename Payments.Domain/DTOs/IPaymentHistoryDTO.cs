using Payments.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.DTOs
{
    public interface IPaymentHistoryDTO
    {
        PaymentHistoryDTO MapToPaymentHistoryDTO(Payment payment);
    }
}
