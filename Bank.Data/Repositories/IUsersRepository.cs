using Bank.Data.Model;

namespace Bank.Data.Repositories
{
    public interface IUsersRepository
    {
        User Authenticate(string username, string password);
    }
}
