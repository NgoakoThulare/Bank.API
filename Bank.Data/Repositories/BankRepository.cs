using Bank.Data.Model;

namespace Bank.Data.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly BankDbContext _db;
        public BankRepository(BankDbContext db) => this._db = db;

        public async Task<BankAccount> Get(int accountNumber)
        {
            return _db.BankAccount.FirstOrDefault(bankAcc => bankAcc.AccountNumber == accountNumber);
        }

        public async Task<ICollection<BankAccount>> GetAll(int IdNumber)
        {   
            return _db.BankAccount.OrderBy(x => x.CreatedOn).ToList();
        }

        public async Task<Withdrawal> Withdraw(int accountNumber, decimal amount)
        {
            var ba = _db.BankAccount.FirstOrDefault(ba => ba.AccountNumber == accountNumber);

            if (ba?.AccountStatus == Common.Enum.AccountStatus.Inactive)
            {
                return new Withdrawal
                {
                    Message = "Account Inactive"
                };
            }

            if (amount > ba?.AccountBalance)
            {
                return new Withdrawal
                {
                    Message = "Insufficient Amount"
                };
            }

            if (ba?.AccountType == Common.Enum.AccountType.FixedDeposit && amount != ba.AccountBalance)
            {
                return new Withdrawal
                {
                    Message = "Only 100% withdrwal allowed on this account"
                };
            }

            var remainingBalance = ba.AccountBalance - amount;
            ba.AccountBalance = remainingBalance;

            _db.BankAccount.Update(ba);
            _db.SaveChanges();

            return new Withdrawal
            {
                Success = true,
                Amount = amount,
                RemainingBalance = remainingBalance
            };
        }
    }
}
