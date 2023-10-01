using NServiceBus;
using NServiceBusBasics.Contracts.Commands;
using NServiceBusBasics.Contracts.Events;
using NServiceBusBasics.Contracts.Messages;

namespace NServiceBusBasics.Receiver.Handlers;

internal sealed class CreateOrderHandler : IHandleMessages<CreateOrder>
{
    public async Task Handle(CreateOrder message, IMessageHandlerContext context)
    {
        Console.WriteLine($"Creating order: {message.OrderId}");
        await Task.Delay(300, context.CancellationToken);

        Console.WriteLine($"Sending CreateOrderReply for order: {message.OrderId}");
        await context.Reply(new CreateOrderReply
        {
            OrderId = message.OrderId
        });

        Console.WriteLine($"Publishing OrderCreated event for order: {message.OrderId}");
        await context.Publish(new OrderCreated
        {
            OrderId = message.OrderId
        });
    }
}