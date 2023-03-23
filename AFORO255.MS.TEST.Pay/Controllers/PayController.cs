using AFORO255.MS.TEST.Pay.DTOs;
using AFORO255.MS.TEST.Pay.Models;
using AFORO255.MS.TEST.Pay.Services;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Pay.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PayController : ControllerBase
{
    private readonly IPaymentServices _paymentServices;

    public PayController(IPaymentServices paymentServices)
    {
        _paymentServices = paymentServices;
    }
    [HttpPost]
    public IActionResult Post([FromBody] PaymentRequest request) {
        //PaymentModel payment = new PaymentModel(request.InvoiceId, request.Amount);
        PaymentModel payment = new PaymentModel 
        { 
            InvoiceId = request.InvoiceId, 
            Amount = request.Amount, 
            CreationDate = DateTime.Now.ToShortDateString()
        };
        payment = _paymentServices.Payment(payment);

        return Ok(payment);
    }
}
