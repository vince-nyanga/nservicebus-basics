using NServiceBus;
using NServiceBusBasics.Contracts.Commands;
using NServiceBusBasics.Sender;


var endpointConfiguration = new SenderEndpointConfigurationFactory()
    .Create();

var endpointInstance = await Endpoint.Start(endpointConfiguration);

while (true)
{
    var command = new CreateOrder
    {
        OrderId = Guid.NewGuid()
    };
    Console.WriteLine($"Sending CreateOrder command {command.OrderId}");
    await endpointInstance.Send(command);

    await Task.Delay(3000);
}