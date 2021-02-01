using NUnit.Framework;
using SGBankApp.BLL;
using SGBankApp.Models.Responses;

namespace SGBankApp.Tests
{
    [TestFixture]
    public class FreeAcctTests
    {
        [Test]
        public void LoadFreeAcctTest()
        {
            AcctService serv = AcctServiceFactory.Create();

            AcctLookupResponse a = serv.LookupAcct("");
            
            Assert.IsNotNull(a.Acct);
            Assert.IsTrue(a.Success);
            Assert.AreEqual("12345", a.Acct.AcctNum);
        }
    }
}