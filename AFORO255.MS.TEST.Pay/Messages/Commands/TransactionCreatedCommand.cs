using Aforo255.Cross.Event.Src.Commands;

namespace AFORO255.MS.TEST.Pay.Messages.Commands;

public class TransactionCreatedCommand : Command
{
    public int IdTransaction { get; protected set; }
    public int InvoiceId { get; protected set; }
    public decimal Amount { get; protected set; }
    public string? CreationDate { get; protected set; }

    public TransactionCreatedCommand(int idTransaction, int invoiceId, decimal amount, string? creationDate)
    {
        this.IdTransaction = idTransaction;
        this.InvoiceId = invoiceId;
        this.Amount = amount;
        this.CreationDate = creationDate;
    }
}
