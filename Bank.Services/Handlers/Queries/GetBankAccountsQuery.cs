using Bank.Services.Dto;
using MediatR;

namespace Bank.Services.Handlers.Queries
{
    public class GetBankAccountsQuery: IRequest<ICollection<BankAccountDto>>
    {
        public int IdNumber { get; set; }
    }
}
