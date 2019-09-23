using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class ErrorMessageWriter : IErrorMessageWriter
    {
        public void Write(string text)
        {
            throw new NotImplementedException();
        }
    }
}
