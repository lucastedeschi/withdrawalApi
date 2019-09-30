using IntermediateTest.Core.Domain.Accounts;
using NUnit.Framework;

namespace IntermediateTest.Core.Tests
{
    public class AccountTests
    {
        private Account account;

        [SetUp]
        public void Setup()
        {
            account = new Account();
        }

        [Test]
        [TestCase(400.0, 400.0 * 0.5)] //Up until $500.00 - 50%
        [TestCase(501.0, 501.0 * 0.4)] //From $500.01 to $1000.00 - 40%
        [TestCase(800.0, 800.0 * 0.4)] //From $500.01 to $1000.00 - 40%
        [TestCase(2000.0, 2000.0 * 0.3)] //From $1000.01 to $5000.00 - 30%
        [TestCase(7000.0, 7000.0 * 0.2)] //From $5000.01 to $10000.00 - 20%
        [TestCase(12000.0, 12000.0 * 0.15)] //From $10000.01 to $15000.00 - 15%
        [TestCase(15000.01, 15000.01 * 0.1)] //From $15000.01 to $20000.00 - 10%
        [TestCase(17000.0, 17000.0 * 0.1)] //From $15000.01 to $20000.00 - 10%
        [TestCase(25000.0, 25000.0 * 0.05)] //From $20000.01 - 5%
        public void MaximumWithdrawalLimitTest(double balance, double limit)
        {
            account.Balance = (decimal)balance;
            Assert.AreEqual(account.GetMaximumWithdrawalLimit(), (decimal)limit);
        }

        [Test]
        [TestCase(400.0, 0.0)] //Up until $500.00 - $0.00
        [TestCase(501.0, 50.0)] //From $500.01 to $1000.00 - $50.00
        [TestCase(1000.01, 150.0)] //From $1000.01 to $5000.00 - $150.00
        [TestCase(2000.0, 150.0)] //From $1000.01 to $5000.00 - $150.00
        [TestCase(7000.0, 650.0)] //From $5000.01 to $10000.00 - $650.00
        [TestCase(10000.01, 1150.0)] //From $10000.01 to $15000.00 - $1150.00
        [TestCase(12000.0, 1150.0)] //From $10000.01 to $15000.00 - $1150.00
        [TestCase(17000.0, 1900.0)] //From $15000.01 to $20000.00 - $1900.00
        [TestCase(25000.0, 2900.0)] //From $20000.01 - $2900.00
        public void FixedMoneyTest(double balance, double fixedMoney)
        {
            account.Balance = (decimal)balance;
            Assert.AreEqual(account.GetFixedMoney(), (decimal)fixedMoney);
        }
    }
}