using AutoMapper;
using Bank.Data.Repositories;
using Bank.Services.Dto;
using Bank.Services.Handlers.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bank.Services.Handlers.Commands
{
    public class GetBankAccountCommand : IRequestHandler<GetBankAccountQuery, BankAccountDto>
    {
        private readonly ILogger<GetBankAccountCommand> _logger;
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public GetBankAccountCommand(ILogger<GetBankAccountCommand> logger,
            IBankRepository bankRepository, IMapper mapper)
        {
            _logger = logger;
            _bankRepository = bankRepository;
            _mapper = mapper;
        }
        public async Task<BankAccountDto> Handle(GetBankAccountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bankAccounts = await _bankRepository.Get(request.AccountNumber);

                _logger.LogDebug($"Bank account retrieved {request.AccountNumber}");

                var response = _mapper.Map<BankAccountDto>(bankAccounts);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
