using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    public interface IFilteredMessageReceiver : IMessageReceiver
    {
        void ErrorMessageHandling(IMessage message);
        void ProcessMessage(IMessage message);
        void ChangeMessageFilter(Type type);
        void ChangeErrorFilter(int errorLevel);
    }
}
