using IntermediateTest.Core.Domain.Employees;
using System.Threading.Tasks;

namespace IntermediateTest.Core.Services.Employees
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeByPersonIdentifier(string personIdentifier);
    }
}
