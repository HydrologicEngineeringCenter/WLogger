using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class HighErrorDiskMessageReceiver : IHighErrorDiskMessageReceiver
    {
        public List<IMessage> messages = new List<IMessage>();
        public string path = "";
        public Type MessageFilter = typeof(IErrorMessage);
        public int ErrorFilter = 2;

        public HighErrorDiskMessageReceiver(string path)
        {
            this.path = path;
        }

        public void Receive(IMessage message)
        {
            ProcessMessage(message);
        }

        public void ReceiveAll(List<IMessage> messages)
        {
            foreach (var message in messages)
            {
                ProcessMessage(message);
            }
        }

        public void Write(IMessage message)
        {
            File.WriteAllText(path, message.GetMessage());
        }

        public void Write(List<IMessage> messages)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                foreach (var message in messages)
                {
                    file.WriteLine(message.GetMessage());
                }
            }
        }

        public void ProcessMessage(IMessage message)
        {
            if (message.GetType() == MessageFilter)
            {
                ErrorMessageHandling(message);
            }
        }

        public void ErrorMessageHandling(IMessage message)
        {
            if (((IErrorMessage)message).GetErrorLevel() == ErrorFilter)
            {
                messages.Add(message);
            }
        }

        public void ChangeMessageFilter(Type type)
        {
            if (type is IMessage || type is null)
                MessageFilter = type;
        }

        public void ChangeErrorFilter(int errorLevel)
        {
            if (errorLevel > 2)
                ErrorFilter = 2;
            else if (errorLevel < -1)
                ErrorFilter = -1;
            else
                ErrorFilter = errorLevel;
        }
    }
}
