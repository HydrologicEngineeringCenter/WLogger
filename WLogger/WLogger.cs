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

        public string Report(Message Wood)
        {
            return "";
        }
    }

    interface Message
    {
        string GetMessage(string text);
        void AppendToMessage(string text);
    }

    class BasicMessage : Message
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

    class ErrorMessage : Message
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

    class TimeStampedMessage : Message
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

    class MessageSender
    {
        
    }

    interface MessageWriter
    {
        void Write(string text);
    }

    class DiskMessageWriter : MessageWriter
    {
        public void Write(string text)
        {
            throw new NotImplementedException();
        }
    }

    class ErrorMessageWriter : MessageWriter
    {
        public void Write(string text)
        {
            throw new NotImplementedException();
        }
    }
}
