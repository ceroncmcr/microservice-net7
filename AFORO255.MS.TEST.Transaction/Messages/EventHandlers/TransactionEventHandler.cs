using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Transaction.Messages.Events;
using AFORO255.MS.TEST.Transaction.Models;
using AFORO255.MS.TEST.Transaction.Services;

namespace AFORO255.MS.TEST.Transaction.Messages.EventHandlers;

public class TransactionEventHandler : IEventHandler<TransactionCreatedEvent>
{
    private readonly ITransactionService _transactionService;

    public TransactionEventHandler(ITransactionService transactionService) => _transactionService = transactionService;

    public Task Handle(TransactionCreatedEvent @event)
    {
        _transactionService.Add(new TransactionModel()
        {
            Amount = @event.Amount,
            CreationDate = @event.CreationDate,
            IdTransaction = @event.IdTransaction,
            InvoiceId = @event.InvoiceId,
        });
        return Task.CompletedTask;
    }
}
