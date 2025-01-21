using Banking_System.Data;
using Banking_System.Interfaces;
using Banking_System.Models;

namespace Banking_System.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(BankingDbContext dbContext) : base(dbContext)
    {

    }
}

}