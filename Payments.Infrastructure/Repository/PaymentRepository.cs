using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Payments.Domain.IRepository;
using Payments.Infrastructure.EFModel;

using Payment_Model = Payments.Domain.Model.Payment;
using Payment_EfModel = Payments.Infrastructure.EFModel.Payment;

namespace Payments.Infrastructure.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentsContext _context;
        private readonly IMapper _iMapper;

        public PaymentRepository(PaymentsContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }

        public async Task<bool> AddPayment(Payment_Model entity)
        {
            Payment_EfModel paymentDb = _iMapper.Map<Payment_EfModel>(entity);
            await _context.Payment.AddAsync(paymentDb);
            await _context.SaveChangesAsync();

            Payment_EfModel checkDb = await _context.Payment.Where(p => p.Id == paymentDb.Id).SingleOrDefaultAsync();

            if (checkDb == null)
                return false;

            return true;
        }

        public async Task<Payment_Model> GetPayment(long id)
        {
            Payment_EfModel paymentDb = await _context.Payment.Where(p => p.Id == id).SingleOrDefaultAsync();
            Payment_Model payment = _iMapper.Map<Payment_Model>(paymentDb);
            return payment;
        }
    }
}
