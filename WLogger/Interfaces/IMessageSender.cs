using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    public interface IMessageSender
    {
        void Send(IMessageReceiver receiver, IMessage message);
        void Send(IMessageReceiver receiver, List<IMessage> messages);

    }
}
