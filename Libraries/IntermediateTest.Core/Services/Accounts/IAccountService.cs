using IntermediateTest.Core.Domain.Employees;
using System.Collections.Generic;

namespace IntermediateTest.Core.Services.Accounts
{
    public interface IAccountService
    {
        IEnumerable<string> VerifyWithdrawal(decimal amount, Employee employee);
        decimal GetAdjustedWithdrawalAmount(decimal amount, Employee employee);
    }
}
