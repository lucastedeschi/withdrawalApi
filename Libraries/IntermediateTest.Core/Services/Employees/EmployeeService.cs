using System.Linq;
using System.Threading.Tasks;
using IntermediateTest.Core.Domain.Accounts;
using IntermediateTest.Core.Domain.Employees;
using IntermediateTest.GovernmentSharedFunds.Services.GovernmentEmployees;

namespace IntermediateTest.Core.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGovernmentEmployeeService _governmentEmployeeService;

        public EmployeeService(IGovernmentEmployeeService governmentEmployeeService)
        {
            _governmentEmployeeService = governmentEmployeeService;
        }

        public async Task<Employee> GetEmployeeByPersonIdentifier(string personIdentifier)
        {
            var governmentEmployee = await _governmentEmployeeService.GetGovernmentEmployeeByPersonIdentifier(personIdentifier);
            if (governmentEmployee == null)
                return null;

            return new Employee
            {
                PersonIdentifier = governmentEmployee.PersonIdentifier,
                BirthDate = governmentEmployee.BirthDate,
                Account = governmentEmployee == null ? new Account() : new Account
                {
                    Balance = governmentEmployee.Account.Balance,
                    Withdrawals = governmentEmployee.Account?.Withdrawals.Select(gw => new Withdrawal
                    {
                        Amount = gw.Amount,
                        CreatedOn = gw.CreatedOn
                    })
                }
            };
        }
    }
}
