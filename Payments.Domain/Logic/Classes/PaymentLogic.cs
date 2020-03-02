using Newtonsoft.Json;
using Payments.Domain.IRepository;
using Payments.Domain.Logic.Interfaces;
using Payments.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Payments.Domain.Logic.Classes
{
    public class PaymentLogic : IPaymentLogic
    {
        private readonly IPaymentRepository _iPaymentRepository;
        private readonly HttpClient _client;

        public PaymentLogic(IPaymentRepository iPaymentRepository, HttpClient client)
        {
            _iPaymentRepository = iPaymentRepository;
            _client = client;
        }

        public async Task<Payment> GetPaymentHistoryById(long id)
        {
            return await _iPaymentRepository.GetPayment(id);
        }

        public async Task<string> SendPayment(Payment payment)
        {
            string cenas = "";

            var myContent = JsonConvert.SerializeObject(payment);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _client.PostAsync("", byteContent).Result;

            //var response = await _client.GetAsync(requestEndpoint);
            cenas = await result.Content.ReadAsStringAsync();

            return cenas;
        }
    }
}
