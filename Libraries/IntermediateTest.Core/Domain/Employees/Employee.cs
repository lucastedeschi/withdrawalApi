using System;
using IntermediateTest.Core.Domain.Accounts;

namespace IntermediateTest.Core.Domain.Employees
{
    public class Employee
    {
        public string PersonIdentifier { get; set; }
        public DateTime BirthDate { get; set; }
        public Account Account { get; set; }
    }
}
