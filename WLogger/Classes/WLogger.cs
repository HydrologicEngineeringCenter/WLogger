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
        private WLogger() { }

        public static WLogger getLogger()
        {
            return self;
        }

        public void Log(IMessage wood)
        {
            
        }

        public void Log(IMessage[] woods)
        {
            foreach (var plank in woods)
            {
                Log(plank);
            }
        }

        public string Report(IMessage Wood)
        {
            return "";
        }
    }
}
