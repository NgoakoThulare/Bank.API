using Bank.Data.Model;

namespace Bank.Data.Repositories
{
    public interface IBankRepository
    {
        Task<ICollection<BankAccount>> GetAll(int IdNumber);
        Task<BankAccount> Get(int accountNumber);
        Task<Withdrawal> Withdraw(int accountNumber, decimal amount);
    }
}
