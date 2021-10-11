using Ebanx.Core.Interfaces;
using Ebanx.Domain.Commands;
using Ebanx.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Ebanx.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet("balance/{account_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int account_id)
        {
            double balance = 0;
            try
            {
                balance = _accountService.GetBalanceFromAccount(account_id);
            }
            catch (InvalidAccountException)
            {
                _logger.LogError($"GetBalance could not find account with id: {account_id}");
                return NotFound(balance);
            }
            catch (Exception)
            {
                _logger.LogError($"GetBalance returned unexpected error for account id: {account_id}");
                return NotFound(balance);
            }

            return Ok(balance);
        }

        [HttpPost("event")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostEvent([FromBody] EventRequest request)
        {
            EventResponse response = null;
            try
            {
                response = _accountService.PostEvent(request);
            }
            catch (InvalidAccountException)
            {
                _logger.LogError($"PostEvent returned InvalidAccountException for data: {JsonConvert.SerializeObject(request)}");
                return NotFound(0);
            }
            catch (Exception)
            {
                _logger.LogError($"PostEvent returned unexpected error for data: {JsonConvert.SerializeObject(request)}");
                return NotFound();
            }

            return Ok();
        }
    }
}
