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

        async Task<bool> ITransactionService.CreateTranasction(Transaction tranactions)
        {
            if (tranactions != null)
            {
                await _unitOfWork.Transactions.Add(tranactions);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        async Task<IEnumerable<Transaction>> ITransactionService.GetAllTrasactions()
        {
            var TranasctionList = await _unitOfWork.Transactions.GetAll();
            return TranasctionList;
        }

        async Task<Transaction> ITransactionService.GetTransctionById(int tranactionId)
        {
            if (tranactionId > 0)
            {
                var transactionDetails = await _unitOfWork.Transactions.GetById(tranactionId);
                if (transactionDetails != null)
                {
                    return transactionDetails;
                }
            }
            return null;
        }
    }
}
