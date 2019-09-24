using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class PayloadMessage : IPayloadMessage
    {
        private string message = "";
        object payload;

        public PayloadMessage(string text, object payload)
        {
            message = text;
            this.payload = payload;
        }

        public string GetMessage() => message;

        public object GetPayload() => payload;
    }
}
