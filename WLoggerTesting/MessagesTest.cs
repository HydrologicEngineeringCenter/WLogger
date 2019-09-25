using Microsoft.VisualStudio.TestTools.UnitTesting;
using WLogger;

namespace MessageTests
{
    [TestClass]
    public class MessagesTest
    {
        [TestMethod]
        public void CreateBasicMessageAndCheckContents()
        {
            var s = "Hello World!";
            IMessage basic = new BasicMessage(s);
            Assert.AreEqual(s, basic.GetMessage());
        }

        [TestMethod]
        public void CreateLowErrorMessageAndCheckContents()
        {
            var e = "Error Occured: BAD121";
            IErrorMessage errorMessage = new ErrorMessage(e, 0);
            Assert.AreEqual(e, errorMessage.GetMessage());
            Assert.AreEqual(0, errorMessage.GetErrorLevel());
        }

        [TestMethod]
        public void CreateMediumErrorMessageAndCheckContents()
        {
            var e = "Error Occured: MOREBAD121";
            IErrorMessage errorMessage = new ErrorMessage(e, 1);
            Assert.AreEqual(e, errorMessage.GetMessage());
            Assert.AreEqual(1, errorMessage.GetErrorLevel());
        }

        [TestMethod]
        public void CreateHighErrorMessageAndCheckContents()
        {
            var e = "Error Occured: VERYBAD121";
            IErrorMessage errorMessage = new ErrorMessage(e, 2);
            Assert.AreEqual(e, errorMessage.GetMessage());
            Assert.AreEqual(2, errorMessage.GetErrorLevel());
        }
    }
    
}
