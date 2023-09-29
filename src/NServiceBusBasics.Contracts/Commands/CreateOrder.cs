namespace NServiceBusBasics.Contracts.Commands;

public sealed record CreateOrder
{
    public required Guid OrderId { get; init; }
}