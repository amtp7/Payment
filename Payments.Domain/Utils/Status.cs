using System.Collections.Generic;

namespace Payments.Domain.Utils
{
    public class Status : IStatus
    {
        private Dictionary<int, string> statusMessages = new Dictionary<int, string>();

        public Status()
        {
            statusMessages.Add(-1, "Payment Failed: Request Failed");
            statusMessages.Add(0, "Payment Succeeded");           
            statusMessages.Add(1, "Payment Failed: Insuficient Funds");
            statusMessages.Add(2, "Payment Failed: Invalid Card");
        }

        public string GetStatusMessage(int statusCode)
        {
            return statusMessages.GetValueOrDefault(statusCode);
        }
    }
}
