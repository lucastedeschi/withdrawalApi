using IntermediateTest.Core.Services.Accounts;
using IntermediateTest.Core.Services.Employees;
using IntermediateTest.GovernmentSharedFunds.Services.GovernmentEmployees;
using Microsoft.Extensions.DependencyInjection;

namespace IntermediateTest.Infrastructure
{
    public static class DependencyRegister
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IGovernmentEmployeeService, GovernmentEmployeeService>();
        }
    }
}
