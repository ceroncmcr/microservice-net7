using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Invoice.DTOs;

public class InvoiceResponse
{
    public int? InvoiceId { get; set; }    
    public decimal? Amount { get; set; }    
    public int? State { get; set; }
}
