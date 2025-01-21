using Banking_System.Data;
using Banking_System.Interfaces;

namespace Banking_System.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankingDbContext _dbContext;
        public IAccountRepository Accounts { get; }
        public ITransactionRepository Transactions { get; }


        public UnitOfWork(BankingDbContext dbContext,
                            IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _dbContext = dbContext;
            Accounts = accountRepository;
            Transactions = transactionRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}


