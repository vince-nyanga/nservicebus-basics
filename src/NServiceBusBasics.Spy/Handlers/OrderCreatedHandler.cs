using NServiceBusBasics.Contracts.Events;

namespace NServiceBusBasics.Spy.Handlers;

internal sealed class OrderCreatedHandler : IHandleMessages<OrderCreated>
{
    public Task Handle(OrderCreated message, IMessageHandlerContext context)
    {
        Console.WriteLine($"Got notified that order was created: {message.OrderId}");
        return Task.CompletedTask;
    }
}