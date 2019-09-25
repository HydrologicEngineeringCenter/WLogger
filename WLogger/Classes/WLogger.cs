using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    public sealed class WLogger
    {
        private static WLogger self = new WLogger();
        private MessageSender sender = new MessageSender();
        private FilteredMessageReceiver receiver = new FilteredMessageReceiver();
        private List<IMessageReceiver> listeners = new List<IMessageReceiver>();

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
            if (receiver.MessageFilter == null)
            {
                foreach (var listener in listeners)
                {
                    foreach (var message in receiver.GetAllMessages())
                    {
                        sender.Send(listener, message);
                    }
                }
            }
            else
            {
                foreach (var listener in listeners)
                {
                    sender.Send(listener, receiver.GetAllMessages());
                }
            }
            
            receiver.Clear();
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
