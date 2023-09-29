using NServiceBusBasics.Contracts.Commands;
using NServiceBusBasics.Sender;

var endpointConfiguration = EndpointConfigurationFactory.Create();

var endpointInstance = await Endpoint.Start(endpointConfiguration);

for (var i = 0; i < 5; i++)
{
    var command = new CreateOrder()
    {
        OrderId = Guid.NewGuid()
    };
    Console.WriteLine($"Send CreatOrder command {command.OrderId}");
    await endpointInstance.Send(command);
}

await endpointInstance.Stop();