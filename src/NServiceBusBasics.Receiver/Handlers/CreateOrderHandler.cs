using NServiceBusBasics.Contracts.Commands;

namespace NServiceBusBasics.Receiver.Handlers;

internal sealed class CreateOrderHandler : IHandleMessages<CreateOrder>
{
    public Task Handle(CreateOrder message, IMessageHandlerContext context)
    {
        Console.WriteLine($"Creating order: {message.OrderId}");
        return Task.CompletedTask;
    }
}