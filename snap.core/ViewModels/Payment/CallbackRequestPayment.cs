using System;
using System.Collections.Generic;
using System.Text;

namespace Snapp.Core.ViewModels.Payment
{
    public class CallbackRequestPayment
    {
        public string PrimaryAccNo { get; set; }

        public string HashedCardNo { get; set; }

        public long OrderId { get; set; }

        public string SwitchResCode { get; set; }

        public string ResCode { get; set; }

        public string Token { get; set; }
    }
}
