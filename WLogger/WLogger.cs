using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class WLogger
    {
        private static WLogger self = new WLogger();
        private WLogger() { }

        public static WLogger getLogger()
        {
            return self;
        }

        public void Log(Message wood)
        {
            
        }

        public void Log(Message[] woods)
        {
            foreach (var plank in woods)
            {
                Log(plank);
            }
        }
    }

    class Message
    {
        private string message;

        public Message(string message)
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return message;
        }
    }
}
