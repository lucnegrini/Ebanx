using Ebanx.Core.Interfaces;
using Ebanx.Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Ebanx.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [Route("balance")]
        [HttpGet]
        public IActionResult Get([FromQuery] string account_id)
        {
            double balance = 0;
            try
            {
                balance = _accountService.GetBalanceFromAccount(account_id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetBalance returned error: {ex.Message} for account id: {account_id}");
                return NotFound(balance);
            }

            return Ok(balance);
        }

        [Route("event")]
        [HttpPost]
        public IActionResult PostEvent([FromBody] EventRequest request)
        {
            IEventResponse response = null;
            try
            {
                response = _accountService.PostEvent(request);
            }
            catch (Exception ex)
            {
                _logger.LogError($"PostEvent returned error: {ex.Message} for data: {JsonConvert.SerializeObject(request)}");
                return NotFound(0);
            }

            return Created("", response);
        }

        [Route("reset")]
        [HttpPost]
        public IActionResult Reset()
        {
            _accountService.ResetState();
            return Ok();
        }
    }
}
