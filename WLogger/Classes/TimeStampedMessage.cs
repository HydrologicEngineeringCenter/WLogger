using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class TimeStampedMessage : ITimeStampedMessage
    {
        private string message = "";

        public TimeStampedMessage(string text)
        {
            message = "[" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "] " + text;
        }

        public string GetMessage()
        {
            return message;
        }
    }
}
