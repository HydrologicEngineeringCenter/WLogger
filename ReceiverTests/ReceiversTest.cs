using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WLogger;

namespace ReceiverTests
{
    [TestClass]
    public class ReceiversTest
    {
        [TestMethod]
        public void AddMessageToMessageReceiver()
        {
            IMessageReceiver receiver = new MessageReceiver();
            var s = "This is a message";
            IMessage basic = new BasicMessage(s);
            receiver.Receive(basic);
            Assert.AreEqual(s, receiver.GetAllMessages()[0].GetMessage());
        }

        [TestMethod]
        public void AddMessagesToMessageReceiver()
        {
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
            receiver.ReceiveAll(temp);
            Assert.AreEqual(s, receiver.GetAllMessages()[0].GetMessage());
            Assert.AreEqual(t, receiver.GetAllMessages()[1].GetMessage());
            Assert.AreEqual(u, receiver.GetAllMessages()[2].GetMessage());
        }

        [TestMethod]
        public void AddDifferentMessagesToMessageReceiver()
        {
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
            receiver.ReceiveAll(temp);
            Assert.AreEqual(s, receiver.GetAllMessages()[0].GetMessage());
            Assert.AreEqual(t, receiver.GetAllMessages()[1].GetMessage());
            Assert.AreEqual(2, ((ErrorMessage)receiver.GetAllMessages()[1]).GetErrorLevel());
            Assert.AreEqual(u, receiver.GetAllMessages()[2].GetMessage());
        }

        [TestMethod]
        public void AddDifferentFilteredMessages()
        {
            IFilteredMessageReceiver receiver = new FilteredMessageReceiver();
            receiver.ChangeMessageFilter(typeof(IErrorMessage));
            receiver.ChangeErrorFilter(2);
            var s = "This is a message";
            var t = "And another...";
            var b = "...blah...";
            var u = "...and another...";
            IMessage basic0 = new BasicMessage(s);
            IMessage basic1 = new ErrorMessage(t, 2);
            IMessage basic2 = new BasicMessage(u);
            IMessage basic3 = new ErrorMessage(b, 1);
            var temp = new List<IMessage>();
            temp.Add(basic0);
            temp.Add(basic1);
            temp.Add(basic2);
            temp.Add(basic3);
            receiver.ReceiveAll(temp);
            var filteredMessages = receiver.GetAllMessages();
            Assert.AreEqual(1, receiver.GetAllMessages().Count);
            Assert.AreNotEqual(s, receiver.GetAllMessages()[0].GetMessage());
            Assert.AreEqual(t, receiver.GetAllMessages()[0].GetMessage());
            Assert.AreNotEqual(b, receiver.GetAllMessages()[0].GetMessage());
            Assert.AreEqual(2, ((ErrorMessage)receiver.GetAllMessages()[0]).GetErrorLevel());
            Assert.AreNotEqual(u, receiver.GetAllMessages()[0].GetMessage());
        }

    }
}
