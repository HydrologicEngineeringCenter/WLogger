﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    public class BasicMessage : IBasicMessage
    {
        private string message = "";

        public BasicMessage(string text) => message = text;

        public string GetMessage() => message;
    }
}
