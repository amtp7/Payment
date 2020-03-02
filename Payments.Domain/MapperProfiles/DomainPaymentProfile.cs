using AutoMapper;
using Payments.Domain.DTOs;
using Payments.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Domain.MapperProfiles
{
    public class DomainPaymentProfile : Profile
    {
        public DomainPaymentProfile()
        {
            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();
        }
    }
}
