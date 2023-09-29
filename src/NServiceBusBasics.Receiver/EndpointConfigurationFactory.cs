namespace NServiceBusBasics.Receiver;

internal static class EndpointConfigurationFactory
{
    private const string RabbitMqConnectionString = "amqp://guest:guest@rabbitmq:5672/";
    public static EndpointConfiguration Create()
    {
        var endpointConfiguration= new EndpointConfiguration("receiver")
            .ConfigureTransport()
            .ConfigureMessageConventions();
        
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.UseSerialization<NewtonsoftJsonSerializer>();
        return endpointConfiguration;
    }

    private static EndpointConfiguration ConfigureTransport(this EndpointConfiguration endpointConfiguration)
    {
        endpointConfiguration.UseTransport<RabbitMQTransport>()
            .UseConventionalRoutingTopology(QueueType.Classic)
            .ConnectionString(RabbitMqConnectionString);
        return endpointConfiguration;
    }

    private static EndpointConfiguration ConfigureMessageConventions(this EndpointConfiguration endpointConfiguration)
    {
        var conventionsBuilder = endpointConfiguration.Conventions();
        conventionsBuilder.DefiningCommandsAs(type => type.Namespace != null && type.Namespace.Contains("Commands"));
        conventionsBuilder.DefiningEventsAs(type => type.Namespace != null && type.Namespace.Contains("Events"));
        conventionsBuilder.DefiningMessagesAs(type => type.Namespace != null && type.Namespace.Contains("Messages"));
        return endpointConfiguration;
    }
}