using Banking_System.Models;

namespace Banking_System.Interfaces
{
    public interface ITransactionService
    {
        Task<bool> CreateTranasction(Transaction tranactions);

        Task<IEnumerable<Transaction>> GetAllTrasactions();

        Task<Account> GetTransctionById(int tranactionId);

        Task<bool> UpdateTransaction(Transaction tranactions);

        Task<bool> DeleteTransaction(int trasactionId);
    }
}
