using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models.Responses;

namespace SGBank.Test
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAcctTest()
        {
            AccountDao aDao = AccountDaoFactory.Create();

            AccountLookupResponse a = aDao.LookupAccount("");
            
            Assert.IsNotNull(a.Acct);
            Assert.IsTrue(a.Success);
            Assert.AreEqual(a.Acct.AcctNum, "12345");
        }
    }
}