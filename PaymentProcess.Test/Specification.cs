using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaymentProcess.Test
{
    [TestClass]
    public class Specification
    {
        [TestInitialize]
        public void Setup()
        {
            Given();
            When();
        }
        protected virtual void Given()
        { }
        protected virtual void When()
        { }

    }
}
