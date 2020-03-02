using BankSimulator.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulator.Controllers
{
    [ApiController]
    public class BankSimulatorController : ControllerBase
    {
        private float money;

        public BankSimulatorController()
        {
            money = 1000;
        }

        [HttpPost]
        [Route("api/[controller]/CheckPayment")]
        public async Task<int> CheckPaymentAsync()
        {
            var result = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                result = await reader.ReadToEndAsync();
            }
            JObject json = JObject.Parse(result);

            PaymentRequest request = new PaymentRequest
            {
                Value = (float)json.SelectToken("Value"),
                Currency = (string)json.SelectToken("Currency"),
                CardNumber = (long)json.SelectToken("CardNumber"),
                CardName = (string)json.SelectToken("CardName"),
                CardExpiryYear = (int)json.SelectToken("CardExpiryYear"),
                CardExpiryMonth = (int)json.SelectToken("CardExpiryMonth"),
                CardCvv = (int)json.SelectToken("CardCvv")
            };

            // SIMULATION OF MONEY VALUE VALIDATION
            if (request.Value > money)
            {
                return 1;
            }

            // TODO: OTHER VALIDATIONS

            return 0;
        }
    }
}
