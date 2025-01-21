using Banking_System.Interfaces;
using Banking_System.Models;

namespace Banking_System.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateTranasction(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            await _unitOfWork.Transactions.Add(transaction);
            return _unitOfWork.Save() > 0;
        }

        public async Task<IEnumerable<Transaction>> GetAllTrasactions()
        {
            return await _unitOfWork.Transactions.GetAll();
        }

        public async Task<Transaction> GetTransctionById(int transactionId)
        {
            if (transactionId <= 0)
                throw new ArgumentException("Transaction ID must be greater than zero.", nameof(transactionId));

            return await _unitOfWork.Transactions.GetById(transactionId);
        }

        public async Task<bool> UpdateTransaction(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            _unitOfWork.Transactions.Update(transaction);
            return _unitOfWork.Save() > 0;
        }

        public async Task<bool> DeleteTransaction(int transactionId)
        {
            var transaction = await _unitOfWork.Transactions.GetById(transactionId);
            if (transaction == null)
                return false;

            _unitOfWork.Transactions.Delete(transaction);
            return _unitOfWork.Save() > 0;
        }
    }
}
