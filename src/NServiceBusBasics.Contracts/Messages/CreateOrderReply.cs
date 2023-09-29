namespace NServiceBusBasics.Contracts.Messages;

public sealed record CreateOrderReply
{
    public required Guid OrderId { get; init; }
}