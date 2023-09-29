using NServiceBusBasics.Contracts.Messages;

namespace NServiceBusBasics.Sender.Handlers;

internal sealed class CreateOrderReplyHandler : IHandleMessages<CreateOrderReply>
{
    public Task Handle(CreateOrderReply message, IMessageHandlerContext context)
    {
        Console.WriteLine($"Received confirmation that order was created: {message.OrderId}");
        
        return Task.CompletedTask;
    }
}