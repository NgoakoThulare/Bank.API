using Bank.Services.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private ISender? _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();


        [HttpGet("Accounts")]
        public async Task<IActionResult> GetBankAccountsAsync([FromQuery] int IdNumber)
        {
            var response = await Mediator.Send(new GetBankAccountsQuery()
            {
                IdNumber = IdNumber
            });

            return Ok(response);
        }

        [HttpGet("Account")]
        public async Task<IActionResult> GetBankAccountAsync([FromQuery] int AccountNumber)
        {
            var response = await Mediator.Send(new GetBankAccountQuery()
            {
                AccountNumber = AccountNumber
            });

            return Ok(response);
        }

        [HttpGet("Withdrawal")]
        public async Task<IActionResult> Withdraw([FromQuery] int AccountNumber, decimal Amount)
        {
            var response = await Mediator.Send(new WithdrawalQuery()
            {
                AccountNumber = AccountNumber,
                Amount = Amount
            });

            return Ok(response);
        }
    }
}
