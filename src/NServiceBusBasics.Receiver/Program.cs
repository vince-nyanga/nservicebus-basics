using NServiceBus;
using NServiceBusBasics.Receiver;

var endpointConfiguration = new ReceiverEndpointConfigurationFactory()
    .Create();

await Endpoint.Start(endpointConfiguration);

while (true)
{
    // to keep application running
}