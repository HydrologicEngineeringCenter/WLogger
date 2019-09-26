using Microsoft.VisualStudio.TestTools.UnitTesting;
using WLogger;

namespace WLoggerTest
{
    [TestClass]
    public class WLoggerTest
    {
        [TestMethod]
        public void CreateWLogger()
        {
            var Logger = WLogger.WLogger.getLogger();
            var a = "This is a regular message.";
            var b = "This is the time I logged a message.";
            var c = "Uh oh, this is pretty bad";
            var d = "Hey this isn't too bad";
            var e = "Now the issue has been fixed!";
            Logger.Log(new BasicMessage(a));
            Logger.Log(new TimeStampedMessage(b));
            Logger.Log(new ErrorMessage(c, 2));
            Logger.Log(new ErrorMessage(d, 1));
            Logger.Log(new TimeStampedMessage(e));
            IMessageReceiver user1 = new MessageReceiver();
            IMessageReceiver fuser1 = new FilteredMessageReceiver(typeof(ITimeStampedMessage));
            IMessageReceiver fuser2 = new FilteredMessageReceiver(typeof(IErrorMessage), 2);
            Logger.AddListener(user1);
            Logger.AddListener(fuser1);
            Logger.AddListener(fuser2);
            Logger.Flush();

            Assert.AreEqual(5, user1.GetAllMessages().Count);
            Assert.AreEqual(a, user1.GetAllMessages()[0].GetMessage());
            Assert.AreEqual(b, user1.GetAllMessages()[1].GetMessage().Substring(23));
            Assert.AreEqual(c, user1.GetAllMessages()[2].GetMessage());
            Assert.AreEqual(d, user1.GetAllMessages()[3].GetMessage());
            Assert.AreEqual(e, user1.GetAllMessages()[4].GetMessage().Substring(23));

            Assert.AreEqual(2, fuser1.GetAllMessages().Count);
            Assert.AreEqual(b, fuser1.GetAllMessages()[0].GetMessage().Substring(23));
            Assert.AreEqual(e, fuser1.GetAllMessages()[1].GetMessage().Substring(23));

            Assert.AreEqual(1, fuser2.GetAllMessages().Count);
            Assert.AreEqual(c, fuser2.GetAllMessages()[0].GetMessage());
            Assert.AreEqual(2, ((IErrorMessage)fuser2.GetAllMessages()[0]).GetErrorLevel());

        }
    }
}
