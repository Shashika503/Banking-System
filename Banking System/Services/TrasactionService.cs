using Banking_System.Interfaces;
using Banking_System.Models;

namespace Banking_System.Services
{
    public class TrasactionService : ITransactionService
    {
          public IUnitOfWork _unitOfWork;

    public TrasactionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CreateTransaction(Transaction transactions)
    {
        if (transactions != null)
        {
            await _unitOfWork.Transactions.Add(transactions);

            var result = _unitOfWork.Save();

            if (result > 0)
                return true;
            else
                return false;
        }
        return false;
    }

    public async Task<bool> DeleteTransaction(int transactionId)
    {
        if (transactionId > 0)
        {
            var TransactionDetails = await _unitOfWork.Accounts.GetById(transactionId);
            if (TransactionDetails != null)
            {
                _unitOfWork.Accounts.Delete(TransactionDetails);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactions()
    {
        var TranasctionList = await _unitOfWork.Transactions.GetAll();
        return TranasctionList;
    }

    public async Task<Transaction> GetTransctionById(int trasactionId)
    {
        if (trasactionId > 0)
        {
            var transactionDetails = await _unitOfWork.Transactions.GetById(trasactionId);
            if (transactionDetails != null)
            {
                return transactionDetails;
            }
        }
        return null;
    }

    public async Task<bool> UpdateTransaction(Transaction tranactions)
    {
        if (tranactions != null)
        {
            var trasaction = await _unitOfWork.Transactions.GetById(tranactions.TransactionId);
            if (trasaction != null)
            {
                trasaction.AccountId = tranactions.AccountId;
                trasaction.TransactionType = tranactions.TransactionType;
                trasaction.Amount = tranactions.Amount;

                    _unitOfWork.Transactions.Update(trasaction);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }

        Task<bool> ITransactionService.CreateTranasction(Transaction tranactions)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Transaction>> ITransactionService.GetAllTrasactions()
        {
            throw new NotImplementedException();
        }

        Task<Account> ITransactionService.GetTransctionById(int tranactionId)
        {
            throw new NotImplementedException();
        }
    }
}
