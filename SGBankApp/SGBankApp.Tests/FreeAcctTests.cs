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

        [Test]
        public void SaveFreeAcctTest()
        {
            const decimal dep = 100.00M;
            AcctService serv = AcctServiceFactory.Create();
            AcctLookupResponse a = serv.LookupAcct("12345");
            decimal oldBal = a.Acct.Balance;
            decimal afterDepBal = a.Acct.Balance + dep;

            AcctDepositResponse rsp = serv.Deposit(a.Acct.AcctNum, dep);
            
            Assert.IsNotNull(rsp.Acct);
            Assert.IsTrue(rsp.Success);
            Assert.AreEqual(rsp.Deposit, dep);
            Assert.AreEqual(rsp.OldBalance, oldBal);
            Assert.AreEqual(rsp.Acct.Balance, afterDepBal);
        }
    }
}