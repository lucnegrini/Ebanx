using Ebanx.Domain.Interfaces;
using Ebanx.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebanx.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly ILogger<BalanceController> _logger;
        private readonly IBalanceService _balanceService;

        public BalanceController(ILogger<BalanceController> logger, IBalanceService balanceService)
        {
            _logger = logger;
            _balanceService = balanceService;
        }

        [HttpGet("{account_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int account_id)
        {
            int balance = 0;
            try
            {
                balance = _balanceService.GetBalanceFromAccount(account_id);
            }
            catch (InvalidAccountException ex)
            {
                _logger.LogError($"Get balance returned error for account id: {account_id}");
                return NotFound(balance);
            }

            return Ok(balance);
        }
    }
}
