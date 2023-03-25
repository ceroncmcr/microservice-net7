using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Pay.DTOs;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Models;
using AFORO255.MS.TEST.Pay.Services;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Pay.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PayController : ControllerBase
{
    private readonly IPaymentServices _paymentServices;
    private readonly IEventBus _eventBus;

    public PayController(IPaymentServices paymentServices, IEventBus eventBus)
    {
        _paymentServices = paymentServices;
        _eventBus = eventBus;
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

        _eventBus.SendCommand(new InvoiceCreatedCommand(payment.IdTransaction, payment.InvoiceId, 
            payment.Amount, payment.CreationDate));

        _eventBus.SendCommand(new TransactionCreatedCommand(payment.IdTransaction, payment.InvoiceId,
            payment.Amount, payment.CreationDate));

        return Ok(payment);
    }
}
