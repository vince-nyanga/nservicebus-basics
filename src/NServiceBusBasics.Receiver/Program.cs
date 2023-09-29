﻿using NServiceBusBasics.Receiver;

var endpointConfiguration = EndpointConfigurationFactory.Create();

await Endpoint.Start(endpointConfiguration);

while (true)
{
    // to keep application running
}