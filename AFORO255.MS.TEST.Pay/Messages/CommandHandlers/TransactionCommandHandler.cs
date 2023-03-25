using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Messages.Events;
using MediatR;

namespace AFORO255.MS.TEST.Pay.Messages.CommandHandlers;

public class TransactionCommandHandler : IRequestHandler<TransactionCreatedCommand, bool>
{
    private readonly IEventBus _eventBus;

    public TransactionCommandHandler(IEventBus eventBus) => _eventBus = eventBus;
    public Task<bool> Handle(TransactionCreatedCommand request, CancellationToken cancellationToken)
    {
        _eventBus.Publish(new TransactionCreatedEvent(request.IdTransaction, request.InvoiceId, request.Amount, request.CreationDate));
        return Task.FromResult(true);
    }
}
