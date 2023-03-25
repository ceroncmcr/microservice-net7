using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Messages.Events;
using MediatR;

namespace AFORO255.MS.TEST.Pay.Messages.CommandHandlers;

public class InvoiceCommandHandler : IRequestHandler<InvoiceCreatedCommand, bool>
{
    private readonly IEventBus _eventBus;

    public InvoiceCommandHandler(IEventBus eventBus) => _eventBus = eventBus; 
    public Task<bool> Handle(InvoiceCreatedCommand request, CancellationToken cancellationToken)
    {
        _eventBus.Publish(new InvoiceCreatedEvent(request.IdTransaction, request.InvoiceId, request.Amount, request.CreationDate));
        return Task.FromResult(true);
    }
}
