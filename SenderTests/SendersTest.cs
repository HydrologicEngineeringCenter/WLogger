using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WLogger;

namespace SenderTests
{
    [TestClass]
    public class SendersTest
    {
        [TestMethod]
        public void CheckSendOneMessage()
        {
            var m = new BasicMessage("Catch This!");
            MessageSender sender = new MessageSender();
            MessageReceiver receiver = new MessageReceiver();
            sender.Send(receiver, m);
            Assert.AreEqual(m.GetMessage(), receiver.GetMessage(0).GetMessage());
        }
        
        [TestMethod]
        public void CheckSendMultipleMessages()
        {
            IMessageSender sender = new MessageSender();
            IMessageReceiver receiver = new MessageReceiver();
            var s = "This is a message";
            var t = "And another...";
            var u = "...and another...";
            IMessage basic0 = new BasicMessage(s);
            IMessage basic1 = new BasicMessage(t);
            IMessage basic2 = new BasicMessage(u);
            var temp = new List<IMessage>();
            temp.Add(basic0);
            temp.Add(basic1);
            temp.Add(basic2);
            sender.Send(receiver, temp);
            Assert.AreEqual(s, receiver.GetAllMessages()[0].GetMessage());
            Assert.AreEqual(t, receiver.GetAllMessages()[1].GetMessage());
            Assert.AreEqual(u, receiver.GetAllMessages()[2].GetMessage());
        }

        [TestMethod]
        public void CheckSendMultipleDifferentMessages()
        {
            IMessageSender sender = new MessageSender();
            IMessageReceiver receiver = new MessageReceiver();
            var s = "This is a message";
            var t = "And another...";
            var u = "...and another...";
            IMessage basic0 = new BasicMessage(s);
            IMessage basic1 = new ErrorMessage(t, 2);
            IMessage basic2 = new BasicMessage(u);
            var temp = new List<IMessage>();
            temp.Add(basic0);
            temp.Add(basic1);
            temp.Add(basic2);
            sender.Send(receiver, temp);
            Assert.AreEqual(s, receiver.GetAllMessages()[0].GetMessage());
            Assert.AreEqual(t, receiver.GetAllMessages()[1].GetMessage());
            Assert.AreEqual(2, ((ErrorMessage)receiver.GetAllMessages()[1]).GetErrorLevel());
            Assert.AreEqual(u, receiver.GetAllMessages()[2].GetMessage());
        }
    }
}
