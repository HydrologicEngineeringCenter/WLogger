using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    interface IDiskMessageReceiver : IMessageReceiver, IDiskMessageWriter
    {

    }
}
