using Aforo255.Cross.Event.Src.Events;

namespace AFORO255.MS.TEST.Pay.Messages.Events;

public class InvoiceCreatedEvent : Event
{
    public int IdTransaction { get; protected set; }
    public int InvoiceId { get; protected set; }
    public decimal Amount { get; protected set; }
    public string? CreationDate { get; protected set; }

    public InvoiceCreatedEvent(int idTransaction, int invoiceId, decimal amount, string? creationDate)
    {
        this.IdTransaction = idTransaction;
        this.InvoiceId = invoiceId;
        this.Amount = amount;
        this.CreationDate = creationDate;
    }
}
