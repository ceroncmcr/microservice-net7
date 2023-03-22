using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Invoice.Models;

public class InvoiceModel
{
    [Key]
    [Column("id_invoice")]
    public int? InvoiceId { get; set; }
    [Column("amount")]
    public decimal? Amount { get; set; }
    [Column("state")]
    public int? State { get; set; }
}
