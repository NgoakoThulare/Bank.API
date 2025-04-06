using Bank.Services.Dto;
using MediatR;

namespace Bank.Services.Handlers.Queries
{
    public class WithdrawalQuery : IRequest<WithdrawalResponseDto>
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
