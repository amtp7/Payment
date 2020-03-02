using Payments.Infrastructure.Mappers.Interfaces;
using System;

using Payment_Model = Payments.Domain.Model.Payment;
using Payment_EF = Payments.Infrastructure.EFModel.Payment;

namespace Payments.Infrastructure.Mappers.Classes
{
    public class PaymentMapper : IPaymentMapper
    {
        public Payment_EF ToEfModel(Payment_Model entity)
        {
            throw new NotImplementedException();
        }

        public Payment_Model ToModel(Payment_EF efEntity)
        {
            throw new NotImplementedException();
        }
    }
}
