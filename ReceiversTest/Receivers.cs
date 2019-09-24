using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WLogger;

namespace WLoggerTesting
{
   [TestClass]
    class Receivers
    {
        [TestMethod]
        public void AddMessageToMessageReceiver()
        {
            MessageReceiver receiver = new MessageReceiver();
            var s = "This is a message";
            BasicMessage basic = new BasicMessage(s);
            receiver.Receive(basic);
            Assert.Equals(s, receiver.messages[0].GetMessage());
        }

        [TestMethod]
        public void AddMessagesToMessageReceiver()
        {
            MessageReceiver receiver = new MessageReceiver();
            var s = "This is a message";
            var t = "And another...";
            var u = "...and another...";
            BasicMessage basic0 = new BasicMessage(s);
            BasicMessage basic1 = new BasicMessage(t);
            BasicMessage basic2 = new BasicMessage(u);
            var temp = new List<IMessage>();
            temp.Add(basic0);
            temp.Add(basic1);
            temp.Add(basic2);
            receiver.ReceiveAll(temp);
            Assert.Equals(s, receiver.messages[0].GetMessage());
            Assert.Equals(t, receiver.messages[1].GetMessage());
            Assert.Equals(u, receiver.messages[2].GetMessage());
        }

        [TestMethod]
        public void AddDifferentMessagesToMessageReceiver()
        {
            MessageReceiver receiver = new MessageReceiver();
            var s = "This is a message";
            var t = "And another...";
            var u = "...and another...";
            BasicMessage basic0 = new BasicMessage(s);
            ErrorMessage basic1 = new ErrorMessage(t, 2);
            BasicMessage basic2 = new BasicMessage(u);
            var temp = new List<IMessage>();
            temp.Add(basic0);
            temp.Add(basic1);
            temp.Add(basic2);
            receiver.ReceiveAll(temp);
            Assert.Equals(s, receiver.messages[0].GetMessage());
            Assert.Equals(t, receiver.messages[1].GetMessage());
            Assert.Equals(2, ((ErrorMessage)receiver.messages[1]).GetErrorLevel());
            Assert.Equals(u, receiver.messages[2].GetMessage());
        }




    }
}
