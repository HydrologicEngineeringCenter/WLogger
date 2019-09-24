using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLogger
{
    public class DiskMessageWriter : IDiskMessageWriter
    {
        public readonly string path = "";

        public DiskMessageWriter(string path) => this.path = path;

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
