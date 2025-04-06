using AutoMapper;
using Bank.Data.Model;
using Bank.Services.Dto;

namespace Bank.Services.Converters
{
    public class BankMappings : Profile
    {
        public BankMappings()
        {
            CreateMap<BankAccount, BankAccountDto>().ReverseMap();
            CreateMap<Withdrawal, WithdrawalResponseDto>().ReverseMap();
        }
    }
}
