using AFORO255.MS.TEST.Transaction.DTOs;
using AFORO255.MS.TEST.Transaction.Models;

namespace AFORO255.MS.TEST.Transaction.Services;

public interface ITransactionService
{
    Task<TransactionResponse> GetById(int invoiceId);

    Task<bool> Add(TransactionModel transactionModel);
}
