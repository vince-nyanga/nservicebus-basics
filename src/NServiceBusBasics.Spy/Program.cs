using NServiceBusBasics.Spy;

var endpointConfiguration = EndpointConfigurationFactory.Create();

await Endpoint.Start(endpointConfiguration);

while (true)
{
    // to keep application running
}