using Common.Enum;

namespace Bank.Services.Dto
{
    public class BankAccountDto
    {
        public int AccountHolderIdNumber { get; set; }
        public string? AccountHolderFirstName { get; set; }
        public string? AccountHolderLastName { get; set; }
        public int AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public string? AccountName { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
