using IntermediateTest.Api.Controllers;
using IntermediateTest.Api.Models;
using IntermediateTest.Core.Domain.Accounts;
using IntermediateTest.Core.Domain.Employees;
using IntermediateTest.Core.Services.Accounts;
using IntermediateTest.Core.Services.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntermediateTest.Api.Tests
{
    public class WithdrawalControllerTests
    {
        private WithdrawalController _withdrawalController;
        private Mock<IEmployeeService> _employeeService;
        private Mock<IAccountService> _accountService;
        private Mock<ILogger<WithdrawalController>> _logger;
        private WithdrawalRequest completedRequest;
        private WithdrawalRequest wrongRequest;

        [SetUp]
        public void Setup()
        {
            var employee = new Employee
            {
                PersonIdentifier = "123456789",
                BirthDate = DateTime.Now.AddYears(-10),
                Account = new Account
                {
                    Balance = 800.00m,
                    Withdrawals = new List<Withdrawal>()
                }
            };

            completedRequest = new WithdrawalRequest
            {
                Amount = 50.0m,
                PersonIdentifier = "123456789"
            };

            wrongRequest = new WithdrawalRequest
            {
                PersonIdentifier = string.Empty
            };

            _employeeService = new Mock<IEmployeeService>();
            _accountService = new Mock<IAccountService>();
            _logger = new Mock<ILogger<WithdrawalController>>();

            _employeeService
                .Setup(s => s.GetEmployeeByPersonIdentifier(completedRequest.PersonIdentifier))
                .Returns(Task.FromResult(employee));

            _accountService
                .Setup(s => s.VerifyWithdrawal(completedRequest.Amount, employee))
                .Returns(new List<string>());

            _accountService
                .Setup(s => s.GetAdjustedWithdrawalAmount(completedRequest.Amount, employee))
                .Returns(100.0m);

            _withdrawalController = new WithdrawalController(_employeeService.Object, _accountService.Object, _logger.Object);
        }

        [Test]
        public void VerifyWithdrawal_Success()
        {
            var apiResult = _withdrawalController.VerifyWithdrawal(completedRequest).Result;
            var response = (WithdrawalResponse)((OkObjectResult)apiResult.Result).Value;

            Assert.AreEqual(response.Allowed, true);
            Assert.AreEqual(response.AdjustedAmount, 100.0m);
            Assert.AreEqual(response.Observations, new List<string>());
            Assert.That(apiResult.Result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void VerifyWithdrawal_Fail()
        {
            var apiResult = _withdrawalController.VerifyWithdrawal(wrongRequest).Result;

            Assert.That(apiResult.Result, Is.InstanceOf<BadRequestObjectResult>());
        }
    }
}