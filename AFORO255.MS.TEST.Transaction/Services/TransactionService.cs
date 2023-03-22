using AFORO255.MS.TEST.Transaction.DTOs;
using AFORO255.MS.TEST.Transaction.Models;
using AFORO255.MS.TEST.Transaction.Persistences;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace AFORO255.MS.TEST.Transaction.Services;

public class TransactionService : ITransactionService
{
    private readonly IMongoBookDBContext _context;
    protected IMongoCollection<TransactionModel> _dbCollection;

    public TransactionService(IMongoBookDBContext context)
    {
        _context = context;
        _dbCollection = _context.GetCollection<TransactionModel>(typeof(TransactionModel).Name);
    }

    public async Task<bool> Add(TransactionModel transactionModel)
    {
        await _dbCollection.InsertOneAsync(transactionModel);
        return true;
    }

    public async Task<TransactionResponse> GetById(int invoiceId)
    {
        var result = await _dbCollection.Find(x => x.InvoiceId == invoiceId).FirstOrDefaultAsync();

        var response = new TransactionResponse();

        if (result is not null)
        {
            response.InvoiceId = result.InvoiceId;
            response.Amount = result.Amount;
            response.CreationDate = result.CreationDate;
            response.IdTransaction = result.IdTransaction;
        }        
        
        return response;
    }
}
