using NServiceBus;
using NServiceBusBasics.Spy;

var endpointConfiguration = new SpyEndpointConfigurationFactory()
    .Create();

await Endpoint.Start(endpointConfiguration);

while (true)
{
    // to keep application running...
}