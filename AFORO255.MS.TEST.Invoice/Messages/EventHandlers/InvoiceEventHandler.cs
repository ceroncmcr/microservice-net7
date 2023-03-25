using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoice.Messages.Events;
using AFORO255.MS.TEST.Invoice.Services;

namespace AFORO255.MS.TEST.Invoice.Messages.EventHandlers;

public class InvoiceEventHandler : IEventHandler<InvoiceCreatedEvent>
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceEventHandler(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    public Task Handle(InvoiceCreatedEvent @event)
    {
        _invoiceService.updateInvoide(@event.InvoiceId);
        return Task.CompletedTask;
    }
}
