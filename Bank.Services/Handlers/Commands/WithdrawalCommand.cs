using AutoMapper;
using Bank.Data.Model;
using Bank.Data.Repositories;
using Bank.Services.Dto;
using Bank.Services.Handlers.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bank.Services.Handlers.Commands
{
    
    public class WithdrawalCommand : IRequestHandler<WithdrawalQuery, WithdrawalResponseDto>
    {
        private readonly ILogger<GetBankAccountCommand> _logger;
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;
        public WithdrawalCommand(ILogger<GetBankAccountCommand> logger,
            IBankRepository bankRepository, IMapper mapper)
        {
            _logger = logger;
            _bankRepository = bankRepository;
            _mapper = mapper;
        }
        public async Task<WithdrawalResponseDto> Handle(WithdrawalQuery request, CancellationToken cancellationToken)
        {
            if (request.Amount <= 0)
            {
                return new WithdrawalResponseDto
                {
                    Message = "Withdrawal amount too low"
                };
            }
            try
            {
                var withdrawal = await _bankRepository.Withdraw(request.AccountNumber, request.Amount);

                _logger.LogDebug($"{request.Amount} Successfully withdrawn from Bank Account {request.AccountNumber}");

                var response = _mapper.Map<WithdrawalResponseDto>(withdrawal);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
