using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    interface IMessageReceiver
    {
        /// <summary>
        /// Receive a list of messages.
        /// </summary>
        /// <param name="messages"></param>
        void ReceiveAll(List<IMessage> messages);
        /// <summary>
        /// Receive a single message.
        /// </summary>
        /// <param name="message"></param>
        void Receive(IMessage message);
    }
}
