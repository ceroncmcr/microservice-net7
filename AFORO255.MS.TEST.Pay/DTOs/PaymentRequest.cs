using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AFORO255.MS.TEST.Pay.DTOs;

public class PaymentRequest
{    
    public int InvoiceId { get; set; }    
    public decimal Amount { get; set; }        
}
