using Aforo255.Cross.Event.Src.Events;

namespace AFORO255.MS.TEST.Transaction.Messages.Events;

public class TransactionCreatedEvent : Event
{
    public int IdTransaction { get; protected set; }
    public int InvoiceId { get; protected set; }
    public decimal Amount { get; protected set; }
    public string? CreationDate { get; protected set; }

    public TransactionCreatedEvent(int idTransaction, int invoiceId, decimal amount, string? creationDate)
    {
        this.IdTransaction = idTransaction;
        this.InvoiceId = invoiceId;
        this.Amount = amount;
        this.CreationDate = creationDate;
    }
}
