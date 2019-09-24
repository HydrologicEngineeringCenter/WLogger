﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    class DiskMessageReceiver : IDiskMessageReceiver
    {
        public List<IMessage> messages = new List<IMessage>();
        public string path = "";
        public DiskMessageReceiver(string path)
        {
            this.path = path;
        }

        public void Receive(IMessage message)
        {
            messages.Add(message);
        }

        public void ReceiveAll(List<IMessage> messages)
        {
            messages.AddRange(messages);
        }

        public void Write(IMessage message)
        {
            File.WriteAllText(path, message.GetMessage());
        }

        public void Write(List<IMessage> messages)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                foreach (var message in messages)
                {
                    file.WriteLine(message.GetMessage());
                }
            }
        }
    }
}
