using Banking_System.Interfaces;
using Banking_System.Models;
using Microsoft.Identity.Client;

namespace Banking_System.Services
{
    public class AccountService : IAccountService
    {
  
        public IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAccount(Account accounts)
        {
            if (accounts != null)
            {
                await _unitOfWork.Accounts.Add(accounts);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteAccount(int accountId)
        {
            if (accountId > 0)
            {
                var AccountDetails = await _unitOfWork.Accounts.GetById(accountId);
                if (AccountDetails != null)
                {
                    _unitOfWork.Accounts.Delete(AccountDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            var productDetailsList = await _unitOfWork.Accounts.GetAll();
            return productDetailsList;
        }

        public async Task<Account> GetAccountById(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Accounts.GetById(productId);
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateAccount(Account accounts)
        {
            if (accounts != null)
            {
                var account = await _unitOfWork.Accounts.GetById(accounts.AccountId);
                if (account != null)
                {
                    account.AccountHolderName = accounts.AccountHolderName;
                    account.AccountType = accounts.AccountType;
                    account.Balance = accounts.Balance;
                    account.DateTime = accounts.DateTime;

                    _unitOfWork.Accounts.Update(account);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}