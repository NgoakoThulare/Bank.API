using AutoMapper;
using Bank.Data.Repositories;
using Bank.Services.Dto;
using Bank.Services.Handlers.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bank.Services.Handlers.Commands
{
    public class GetBankAccountsCommand : IRequestHandler<GetBankAccountsQuery, ICollection<BankAccountDto>>
    {
        private readonly ILogger<GetBankAccountsCommand> _logger;
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public GetBankAccountsCommand(ILogger<GetBankAccountsCommand> logger,
            IBankRepository bankRepository, IMapper mapper)
        {
            _logger = logger;
            _bankRepository = bankRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<BankAccountDto>> Handle(GetBankAccountsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bankAccounts = await _bankRepository.GetAll(request.IdNumber);

                _logger.LogDebug($"Bank accounts retrieved for client {request.IdNumber}");

                var response = _mapper.Map<ICollection<BankAccountDto>>(bankAccounts);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
