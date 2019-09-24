using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class MessageReceiver : IMessageReceiver
    {
        public List<IMessage> messages = new List<IMessage>();

        public MessageReceiver() { }

        public void ReceiveAll(List<IMessage> messages)
        {
            messages.AddRange(messages);
        }
        public void Receive(IMessage message)
        {
            messages.Add(message);
        }
    }
}
