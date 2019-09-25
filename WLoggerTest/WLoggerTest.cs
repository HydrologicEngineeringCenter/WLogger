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
            Logger.Log(new BasicMessage("This is a regular message."));
            Logger.Log(new TimeStampedMessage("This is the time I logged a message."));
            Logger.Log(new ErrorMessage("Uh oh, this is pretty bad", 2));
            Logger.Log(new ErrorMessage("Hey this isn't too bad", 1));
            Logger.Log(new TimeStampedMessage("Now the issue has been fixed!"));
            IMessageReceiver user1 = new MessageReceiver();
            IMessageReceiver fuser1 = new FilteredMessageReceiver();
            IMessageReceiver fuser2 = new FilteredMessageReceiver(typeof(IErrorMessage), 1);
            Logger.AddListener(user1);
            Logger.AddListener(fuser1);
            Logger.AddListener(fuser2);
            Logger.Flush();



        }
    }
}