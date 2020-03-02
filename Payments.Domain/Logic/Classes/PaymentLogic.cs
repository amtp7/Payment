using AutoMapper;
using Newtonsoft.Json;
using Payments.Domain.DTOs;
using Payments.Domain.IRepository;
using Payments.Domain.Logic.Interfaces;
using Payments.Domain.Model;
using Payments.Domain.Utils;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Payments.Domain.Logic.Classes
{
    public class PaymentLogic : IPaymentLogic
    {
        private readonly IPaymentRepository _iPaymentRepository;
        private readonly HttpClient _client;
        private readonly IMapper _iMapper;
        private readonly IStatus _iStatus;
        private readonly IPaymentHistoryDTO _iPaymentHistoryDTO;

        public PaymentLogic(IPaymentRepository iPaymentRepository, HttpClient client, IMapper iMapper, IStatus iStatus, IPaymentHistoryDTO iPaymentHistoryDTO)
        {
            _iPaymentRepository = iPaymentRepository;
            _client = client;
            _iMapper = iMapper;
            _iStatus = iStatus;
            _iPaymentHistoryDTO = iPaymentHistoryDTO;
        }

        public async Task<PaymentHistoryDTO> GetPaymentHistoryById(long id)
        {
            Payment payment = await _iPaymentRepository.GetPayment(id);
            PaymentHistoryDTO paymentHistoryDTO = _iPaymentHistoryDTO.MapToPaymentHistoryDTO(payment);
            return paymentHistoryDTO;
        }

        public async Task<string> SendPayment(Payment payment)
        {
            int response;
            try
            {
                PaymentDTO paymentDTO = _iMapper.Map<PaymentDTO>(payment);

                var myContent = JsonConvert.SerializeObject(paymentDTO);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = _client.PostAsync("", byteContent).Result;
                response = int.Parse(await result.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                // TODO: LOGGING
                return _iStatus.GetStatusMessage(-1);
            }

            payment.Status = response;
            await SavePaymentHistory(payment);

            return _iStatus.GetStatusMessage(response);
        }

        private async Task<bool> SavePaymentHistory(Payment payment)
        {
            int retry = 0;

            bool isInserted = await _iPaymentRepository.AddPayment(payment);

            while (retry < 3)
            {
                if (isInserted)
                    return true;

                await SavePaymentHistory(payment);
                retry += 1;
            }
            // LOGGING: FAILED HISTORY SAVE
            return false;
        }
    }
}
