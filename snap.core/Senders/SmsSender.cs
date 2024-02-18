using System;
using System.Collections.Generic;
using System.Text;

using Kavenegar;

namespace Snapp.Core.Senders
{
    public static class SmsSender
    {
        public static void VerifySend(string to, string template, string token)
        {
            var api = new KavenegarApi("");

            var strTo = to;
            var strTemplate = template;
            var strToken = token;

            api.VerifyLookup(strTo, strToken, strTemplate);
        }
    }
}
