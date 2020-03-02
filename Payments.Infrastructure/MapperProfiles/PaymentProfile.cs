using Payment_Model = Payments.Domain.Model.Payment;
using Payment_EfModel = Payments.Infrastructure.EFModel.Payment;
using AutoMapper;

namespace Payments.Infrastructure.MapperProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment_Model, Payment_EfModel>();
            CreateMap<Payment_EfModel, Payment_Model>();
        }
    }
}
