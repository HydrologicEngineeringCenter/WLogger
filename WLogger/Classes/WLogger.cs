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
        private List<IMessage> messages = new List<IMessage>();

        private WLogger() { }

        public static WLogger getLogger()
        {
            return self;
        }

        public void Log(IMessage wood)
        {
            messages.Add(wood);
        }

        public void Log(List<IMessage> woods)
        {
            messages.AddRange(woods);
        }

        public List<IMessage> Flush()
        {
            return messages;
        }

        public IMessage GetLatestMessage()
        {
            return messages[0];
        }

        public void WashAll()
        {
            messages.Clear();
        }

        public void Wash(int index)
        {
            messages.RemoveAt(index);
        }
    }
}
