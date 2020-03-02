using Payment_Model = Payments.Domain.Model.Payment;
using Payment_EF = Payments.Infrastructure.EFModel.Payment;

namespace Payments.Infrastructure.Mappers.Interfaces
{
    public interface IPaymentMapper
    {
        Payment_Model ToModel(Payment_EF efEntity);
        Payment_EF ToEfModel(Payment_Model entity);
    }
}
