using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Pay.Models;

public class PaymentModel
{
    //public PaymentModel(int invoiceId, decimal amount)
    //{
    //    this.InvoiceId = invoiceId;
    //    this.Amount = amount;
    //    this.CreationDate = DateTime.Now.ToShortDateString();
    //}

    [Key]
    [Column("id_transaccion")]
    public int IdTransaction { get; set; }
    [Column("id_invoice")]
    public int InvoiceId { get; set; }
    [Column("amount")]
    public decimal Amount { get; set; }
    [Column("date")]
    public string? CreationDate { get; set; }
}
