using Ebanx.Core.Interfaces;
using Ebanx.Domain;
using Ebanx.Domain.Commands;
using Ebanx.Domain.Enums;
using Ebanx.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;

namespace Ebanx.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly Dictionary<string, Func<EventRequest, IEventResponse>> _eventHandlers;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _eventHandlers = new Dictionary<string, Func<EventRequest, IEventResponse>>
            {
                { "deposit", HandleDeposit },
                { "withdraw", HandleWithdraw },
                { "transfer", HandleTransfer }
            };
        }

        public double GetBalanceFromAccount(string accountId)
        {
            var account = _accountRepository.GetAccountById(accountId);

            return account.Balance;
        }

        public IEventResponse PostEvent(EventRequest request)
        {
            if (!_eventHandlers.TryGetValue(request.type.ToLower(), out Func<EventRequest, IEventResponse> action))
                throw new Exception();

            return action.Invoke(request);
        }

        private DepositResponse HandleDeposit(EventRequest request)
        {
            var balance = _accountRepository.Deposit(request.destination, request.amount);

            return new DepositResponse()
            {
                destination = new AccountResponse()
                {
                    id = request.destination,
                    balance = balance
                }
            };
        }

        private WithdrawResponse HandleWithdraw(EventRequest request)
        {
            var balance = _accountRepository.Withdraw(request.origin, request.amount);

            return new WithdrawResponse()
            {
                origin = new AccountResponse()
                {
                    id = request.origin,
                    balance = balance
                }
            };
        }

        private TransferResponse HandleTransfer(EventRequest request)
        {
            var originBalance = _accountRepository.Withdraw(request.origin, request.amount);
            var destinationBalance = _accountRepository.Deposit(request.destination, request.amount);

            return new TransferResponse()
            {
                destination = new AccountResponse()
                {
                    id = request.destination,
                    balance = destinationBalance
                },
                origin = new AccountResponse()
                {
                    id = request.origin,
                    balance = originBalance
                }
            };
        }

        public void ResetState()
        {
            _accountRepository.Reset();
            return;
        }
    }
}
