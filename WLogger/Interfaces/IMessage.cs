using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    interface IMessage
    {
        string GetMessage(string text);
        void AppendToMessage(string text);
    }
}
