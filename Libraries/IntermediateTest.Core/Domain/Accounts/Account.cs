using System.Collections.Generic;

namespace IntermediateTest.Core.Domain.Accounts
{
    public class Account
    {
        public Account()
        {
            Withdrawals = new List<Withdrawal>();
        }

        public decimal Balance { get; set; }
        public IEnumerable<Withdrawal> Withdrawals { get; set; }

        public decimal GetMaximumWithdrawalLimit()
        {
            if (Balance >= 20000.01m)
                return Balance * 0.05m;

            if (Balance >= 15000.01m)
                return Balance * 0.1m;

            if (Balance >= 10000.01m)
                return Balance * 0.15m;

            if (Balance >= 5000.01m)
                return Balance * 0.2m;

            if (Balance >= 1000.01m)
                return Balance * 0.3m;

            if (Balance >= 500.01m)
                return Balance * 0.4m;

            return Balance * 0.5m;
        }

        public decimal GetFixedMoney()
        {
            if (Balance >= 20000.01m)
                return 2900m;

            if (Balance >= 15000.01m)
                return 1900m;

            if (Balance >= 10000.01m)
                return 1150m;

            if (Balance >= 5000.01m)
                return 650m;

            if (Balance >= 1000.01m)
                return 150m;

            if (Balance >= 500.01m)
                return 50m;

            return decimal.Zero;
        }
    }
}
