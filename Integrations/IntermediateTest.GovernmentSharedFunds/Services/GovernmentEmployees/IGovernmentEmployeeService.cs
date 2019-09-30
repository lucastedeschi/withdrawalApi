using IntermediateTest.GovernmentSharedFunds.Models.GovernmentEmployees;
using System.Threading.Tasks;

namespace IntermediateTest.GovernmentSharedFunds.Services.GovernmentEmployees
{
    public interface IGovernmentEmployeeService
    {
        Task<GovernmentEmployeeResponse> GetGovernmentEmployeeByPersonIdentifier(string personIdentifier);
    }
}
