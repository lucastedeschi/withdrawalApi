using System;
using System.Collections.Generic;

namespace IntermediateTest.GovernmentSharedFunds.Models.GovernmentEmployees
{
    public class GovernmentEmployeeResponse
    {
        public string PersonIdentifier { get; set; }
        public DateTime BirthDate { get; set; }
        public GovernmentAccount Account { get; set; }

        public class GovernmentAccount
        {
            public decimal Balance { get; set; }
            public IEnumerable<GovernmentWithdrawal> Withdrawals { get; set; }

            public class GovernmentWithdrawal
            {
                public decimal Amount { get; set; }
                public DateTime CreatedOn { get; set; }
            }
        }
    }
}
