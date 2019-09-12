using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class WLogger
    {
        private static WLogger self = new WLogger();
        private WLogger() { }

        public static WLogger getLogger()
        {
            return self;
        }
    }
}
