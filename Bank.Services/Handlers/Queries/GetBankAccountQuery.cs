using Bank.Services.Dto;
using MediatR;

namespace Bank.Services.Handlers.Queries
{
    public class GetBankAccountQuery : IRequest<BankAccountDto>
    {
        public int AccountNumber { get; set; }
    }
}
