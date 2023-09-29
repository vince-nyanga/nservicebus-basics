namespace NServiceBusBasics.Contracts.Events;

public sealed record OrderCreated
{
    public required Guid OrderId { get; init; }
}