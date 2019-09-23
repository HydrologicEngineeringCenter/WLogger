using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class ErrorMessage : IErrorMessage
    {
        
        private int ErrorLevel = 0;
        private string message = "";

        public ErrorMessage(string text, int errorLevel = 0)
        {
            message = text;
            ErrorValueProcessing(errorLevel);
        }

        private void ErrorValueProcessing(int error)
        {
            if (error > 2)
                ErrorLevel = 2;
            else if (error < 0)
                ErrorLevel = 0;
            else
                ErrorLevel = error;
        }

        public string GetMessage()
        {
            return message;
        }
    }
}
