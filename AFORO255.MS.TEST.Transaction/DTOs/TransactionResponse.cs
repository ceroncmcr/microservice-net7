namespace AFORO255.MS.TEST.Transaction.DTOs;

public class TransactionResponse
{
    public int? IdTransaction { get; set; }
    public int? InvoiceId { get; set; }
    public decimal? Amount { get; set; }
    public string? CreationDate { get; set; }
}
