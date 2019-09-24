using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class MessageSender : IMessageSender
    {
        public MessageSender()
        {
        }

        public void Send(IMessageReceiver receiver, IMessage message)
        {
            receiver.Receive(message);
        }

        public void Send(IMessageReceiver receiver, List<IMessage> messages)
        {
            receiver.ReceiveAll(messages);
        }
    }
}
