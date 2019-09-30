using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntermediateTest.GovernmentSharedFunds.Models.GovernmentEmployees;
using static IntermediateTest.GovernmentSharedFunds.Models.GovernmentEmployees.GovernmentEmployeeResponse.GovernmentAccount;

namespace IntermediateTest.GovernmentSharedFunds.Services.GovernmentEmployees
{
    public class GovernmentEmployeeService : IGovernmentEmployeeService
    {
        public async Task<GovernmentEmployeeResponse> GetGovernmentEmployeeByPersonIdentifier(string personIdentifier)
        {
            //Mocked results
            switch (personIdentifier) {
                case "123654789":
                    return new GovernmentEmployeeResponse
                    {
                        PersonIdentifier = personIdentifier,
                        BirthDate = new DateTime(1974, 05, 28),
                        Account = new GovernmentEmployeeResponse.GovernmentAccount
                        {
                            Balance = 400.00m,
                            Withdrawals = new List<GovernmentWithdrawal>()
                        }

                    };
                case "123456789":
                    return new GovernmentEmployeeResponse
                    {
                        PersonIdentifier = personIdentifier,
                        BirthDate = DateTime.UtcNow.AddYears(-23),
                        Account = new GovernmentEmployeeResponse.GovernmentAccount
                        {
                            Balance = 800.00m,
                            Withdrawals = new List<GovernmentWithdrawal>()
                        }

                    };
                case "987654321":
                    return new GovernmentEmployeeResponse
                    {
                        PersonIdentifier = personIdentifier,
                        BirthDate = DateTime.UtcNow.AddYears(-44),
                        Account = new GovernmentEmployeeResponse.GovernmentAccount
                        {
                            Balance = 22000.00m,
                            Withdrawals = new List<GovernmentWithdrawal> { 
                                new GovernmentWithdrawal
                                {
                                    Amount = 550.00m,
                                    CreatedOn = DateTime.UtcNow.AddYears(-2)
                                },
                                new GovernmentWithdrawal
                                {
                                    Amount = 1050.00m,
                                    CreatedOn = DateTime.UtcNow.AddYears(-1)
                                },
                            }
                        }

                    };
                case "123789456":
                    return new GovernmentEmployeeResponse
                    {
                        PersonIdentifier = personIdentifier,
                        BirthDate = DateTime.UtcNow.AddYears(-28).Date,
                        Account = new GovernmentEmployeeResponse.GovernmentAccount
                        {
                            Balance = 12500.00m,
                            Withdrawals = new List<GovernmentWithdrawal> {
                                new GovernmentWithdrawal
                                {
                                    Amount = 450.00m,
                                    CreatedOn = DateTime.UtcNow.AddYears(-2)
                                },
                                new GovernmentWithdrawal
                                {
                                    Amount = 550.00m,
                                    CreatedOn = DateTime.UtcNow.AddYears(-1)
                                },
                                new GovernmentWithdrawal
                                {
                                    Amount = 450.00m,
                                    CreatedOn = DateTime.UtcNow.Date
                                },
                            }
                        }
                    };
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
