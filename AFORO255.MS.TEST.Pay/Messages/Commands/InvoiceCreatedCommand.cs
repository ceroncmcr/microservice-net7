using Aforo255.Cross.Event.Src.Commands;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AFORO255.MS.TEST.Pay.Messages.Commands;

public class InvoiceCreatedCommand : Command
{
    public int IdTransaction { get; protected set; }    
    public int InvoiceId { get; protected set; }    
    public decimal Amount { get; protected set; }    
    public string? CreationDate { get; protected set; }

    public InvoiceCreatedCommand(int idTransaction, int invoiceId, decimal amount, string? creationDate)
    {
        this.IdTransaction = idTransaction;
        this.InvoiceId = invoiceId;
        this.Amount = amount;
        this.CreationDate = creationDate;
    }
}
