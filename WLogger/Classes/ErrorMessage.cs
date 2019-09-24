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

        /// <summary>
        /// Write an error message with an error level of 0, 1, or 2 indicating
        /// an error of low, medium, and high, respectively.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="errorLevel"></param>
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

        public string GetMessage() => message;

        public int GetErrorLevel()
        {
            return ErrorLevel;
        }
    }
}
