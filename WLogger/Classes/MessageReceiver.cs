using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    public class MessageReceiver : IMessageReceiver
    {
        private List<IMessage> messages = new List<IMessage>();

        public MessageReceiver() { }

        public void ReceiveAll(List<IMessage> messages)
        {
            this.messages.AddRange(messages);
        }
        public void Receive(IMessage message)
        {
            this.messages.Add(message);
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
