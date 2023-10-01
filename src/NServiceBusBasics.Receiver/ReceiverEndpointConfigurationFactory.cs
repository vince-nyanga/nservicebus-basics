using NServiceBus;
using NServiceBusBasics.Shared;

namespace NServiceBusBasics.Receiver;

internal sealed class ReceiverEndpointConfigurationFactory : AbstractEndpointConfigurationFactory
{
    public ReceiverEndpointConfigurationFactory()
        : base("receiver")
    {
    }

    protected override void ConfigureTransportSettings(TransportExtensions<RabbitMQTransport> transport)
    {
        base.ConfigureTransportSettings(transport);
        transport.Transactions(TransportTransactionMode.ReceiveOnly);
    }
}