using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    sealed class WLogger
    {
        private static WLogger self = new WLogger();
        private MessageSender sender = new MessageSender();
        private HighErrorDiskMessageReceiver receiver = new HighErrorDiskMessageReceiver();
        private List<IMessageReceiver> listeners = new List<IMessageReceiver>();
        public Type MessageFilter = null;
        public int ErrorFilter = -1;

        private WLogger()
        {
        }

        public static WLogger getLogger() => self;

        public void Log(IMessage wood)
        {
            receiver.Receive(wood);
        }

        public void Log(List<IMessage> woods)
        {
            foreach (var plank in woods)
            {
                receiver.Receive(plank);
            }
        }

        public void Flush()
        {
            if (FilterMessages())
            {
                foreach (var listener in listeners)
                {
                    foreach (var message in messages)
                    {
                        ProcessMessage(listener, message);
                    }
                }
            }
            else
            {
                foreach (var listener in listeners)
                {
                    sender.Send(listener, messages);
                }
            }
            
            messages.Clear();
        }

        private void ProcessMessage(IMessageReceiver listener, IMessage message)
        {
            if (MessageFilter == null)
            {
                sender.Send(listener, message);
            }
            else if (message.GetType() == MessageFilter)
            {
                if (MessageFilter == typeof(IErrorMessage))
                {
                    ErrorMessageHandling(listener, message);
                }
                else
                {
                    sender.Send(listener, message);
                }
            }
        }

        private void ErrorMessageHandling(IMessageReceiver listener, IMessage message)
        {
            if (((IErrorMessage)message).GetErrorLevel() == ErrorFilter)
            {
                sender.Send(listener, message);
            }
        }

        private bool FilterMessages()
        {
            if (ErrorFilter == -1 && MessageFilter == null)
            {
                return false;
            }
            return true;
        }

        public void GetNextMessage()
        {
            foreach (var listener in listeners)
            {
                if (messages.Count > 0)
                    listener.Receive(messages[0]);
            }
            messages.RemoveAt(0);
        }

        public void AddListener(IMessageReceiver listener) => listeners.Add(listener);

        public void ChangeMessageFilter(Type type)
        {
            receiver.ChangeMessageFilter(type);
        }

        public void ChangeErrorFilter(int errorLevel)
        {
            receiver.ChangeErrorFilter(errorLevel);
        }
    }
}
