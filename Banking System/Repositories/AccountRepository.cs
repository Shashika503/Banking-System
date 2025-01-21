using Banking_System.Data;
using Banking_System.Interfaces;
using Banking_System.Models;

namespace Banking_System.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(BankingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
