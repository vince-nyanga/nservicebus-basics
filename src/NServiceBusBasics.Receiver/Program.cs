using NServiceBusBasics.Receiver;

var endpointConfiguration = EndpointConfigurationFactory.Create();

Console.WriteLine("Starting receiver");
var endpointInstance = await Endpoint.Start(endpointConfiguration);

while (true)
{
    // to keep application running
}