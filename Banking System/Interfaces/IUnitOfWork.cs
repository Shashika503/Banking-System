using Banking_System.Repositories;

namespace Banking_System.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }

        ITransactionRepository Transactions { get; }


        int Save();
    }
}
