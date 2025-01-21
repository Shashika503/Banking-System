using Banking_System.Models;

namespace Banking_System.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CreateAccount(Account accounts);

        Task<IEnumerable<Account>> GetAllAccounts();

        Task<Account> GetAccountById(int accountId);

        Task<bool> UpdateAccount(Account accounts);

        Task<bool> DeleteAccount(int accountId);
    }
}
