using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class PayloadMessage : IPayloadMessage
    {
        public void AppendToMessage(string text)
        {
            throw new NotImplementedException();
        }

        public string GetMessage(string text)
        {
            throw new NotImplementedException();
        }
    }
}
