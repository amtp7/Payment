using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankSimulatorController : ControllerBase
    {
        public BankSimulatorController()
        {
        }

        [HttpPost]
        public string CheckPayment(HttpRequest payment)
        {
            var result = payment;
            return "CONFERE!";
        }
    }
}
