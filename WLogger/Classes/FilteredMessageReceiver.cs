using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    public class FilteredMessageReceiver : IFilteredMessageReceiver
    {
        private List<IMessage> messages = new List<IMessage>();
        public Type MessageFilter = null;
        public int ErrorFilter = -1;
        
        public FilteredMessageReceiver(Type messageFilter = null, int errorFilter = -1)
        {
            ChangeMessageFilter(messageFilter);
            ChangeErrorFilter(errorFilter);
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

        public void ProcessMessage(IMessage message)
        {
            if (MessageFilter == null)
                messages.Add(message);
            else if (MessageFilter.IsAssignableFrom(message.GetType()))
            {
                if (MessageFilter == typeof(IErrorMessage))
                    ErrorMessageHandling(message);
                else
                    messages.Add(message);
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
            if (typeof(IMessage).IsAssignableFrom(type) || type is null)
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

        public IMessage GetMessage(int index)
        {
            return messages[index];
        }

        public List<IMessage> GetAllMessages()
        {
            return messages;
        }

        public void Clear()
        {
            messages.Clear();
        }
    }
}
