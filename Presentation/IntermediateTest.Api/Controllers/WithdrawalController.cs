using System;
using System.Linq;
using System.Threading.Tasks;
using IntermediateTest.Api.Models;
using IntermediateTest.Core.Services.Accounts;
using IntermediateTest.Core.Services.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IntermediateTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawalController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAccountService _accountService;
        private readonly ILogger<WithdrawalController> _logger;

        public WithdrawalController(IEmployeeService employeeService,
            IAccountService accountService,
            ILogger<WithdrawalController> logger)
        {
            _employeeService = employeeService;
            _accountService = accountService;
            _logger = logger;
        }

        // POST: api/Withdrawal
        [HttpPost]
        public async Task<ActionResult<WithdrawalResponse>> VerifyWithdrawal(WithdrawalRequest request) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (string.IsNullOrEmpty(request.PersonIdentifier))
                    return BadRequest("PersonIdentifier is empty");

                if (request.Amount <= decimal.Zero)
                    return BadRequest("Amount for withdrawal must be greater than zero");

                var employee = await _employeeService.GetEmployeeByPersonIdentifier(request.PersonIdentifier);
                if (employee == null)
                    return BadRequest("Employee not found");

                var adjustedAmount = decimal.Zero;
                var observations = _accountService.VerifyWithdrawal(request.Amount, employee);

                if (!observations.Any())
                    adjustedAmount = _accountService.GetAdjustedWithdrawalAmount(request.Amount, employee);

                return Ok(new WithdrawalResponse
                {
                    Allowed = !observations.Any(),
                    Observations = observations.ToList(),
                    AdjustedAmount = adjustedAmount
                });
            } catch(Exception ex)
            {
                var friendlyMessage = $"An error occurred while checking a withdrawal (Person Identifier: {request.PersonIdentifier}, Amount: {request.Amount})";
                _logger.LogError(ex, friendlyMessage);

                return BadRequest($"{friendlyMessage}. Please, contact the support");
            }        
        }
    }
}
