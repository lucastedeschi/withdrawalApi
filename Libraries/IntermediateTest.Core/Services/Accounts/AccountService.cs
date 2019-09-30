using System;
using System.Collections.Generic;
using System.Linq;
using IntermediateTest.Core.Domain.Employees;

namespace IntermediateTest.Core.Services.Accounts
{
    public class AccountService : IAccountService
    {
        public IEnumerable<string> VerifyWithdrawal(decimal amount, Employee employee)
        {
            var observations = new List<string>();

            var today = DateTime.UtcNow;
            if (employee.BirthDate.Day != today.Day || employee.BirthDate.Month != today.Month)
                observations.Add("Withdrawal may only be made on the day of the employee's birth");

            var withdrawalLimit = employee.Account.GetMaximumWithdrawalLimit();
            if (amount > withdrawalLimit)
                observations.Add($"The withdrawal limit is {withdrawalLimit}");

            var withdrawals = employee.Account.Withdrawals;
            if (withdrawals.Any())
            {
                var lastWithdrawal = withdrawals.OrderByDescending(w => w.CreatedOn).FirstOrDefault();
                if (lastWithdrawal.CreatedOn.Date == DateTime.UtcNow.Date)
                    observations.Add("A withdrawal has already been made today");
            }
           
            return observations;
        }

        public decimal GetAdjustedWithdrawalAmount(decimal amount, Employee employee) => amount + employee.Account.GetFixedMoney();
    }
}
