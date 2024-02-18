using System;
using System.Collections.Generic;
using System.Text;

namespace Snapp.Core.ViewModels.Payment
{
    public class RequestPaymentResult
    {
        public int ResCode { get; set; }

        public string Description { get; set; }

        public string Token { get; set; }
    }
}
