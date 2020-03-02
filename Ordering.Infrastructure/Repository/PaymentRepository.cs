using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Payments.Domain.IRepository;
using Payments.Infrastructure.EFModel;

using Payment_Model = Payments.Domain.Model.Payment;

namespace Payments.Infrastructure.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentsContext _context;
        private readonly IMapper _mapper;

        public PaymentRepository(PaymentsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddPayment(Payment_Model entity)
        {
            throw new NotImplementedException();
        }

        public void DeletePayment(Payment_Model entity)
        {
            throw new NotImplementedException();
        }

        public List<Payment_Model> GetAllPayments()
        {
            throw new NotImplementedException();
        }

        public async Task<Payment_Model> GetPayment(long id)
        {
            Payment paymentDb = await _context.Payment.Where(p => p.Id == id).SingleOrDefaultAsync();
            Payment_Model payment = _mapper.Map<Payment_Model>(paymentDb);
            return payment;
        }

        public void UpdatePayment(Payment_Model dbEntity, Payment_Model entity)
        {
            throw new NotImplementedException();
        }
    }
}
