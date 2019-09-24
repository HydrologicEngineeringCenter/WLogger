using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    public interface IMessageWriter
    {
        void Write(IMessage message);
        void Write(List<IMessage> messages);
    }
}
