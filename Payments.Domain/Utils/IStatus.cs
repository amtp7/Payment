using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Domain.Utils
{
    public interface IStatus
    {
        string GetStatusMessage(int statusCode);
    }
}
