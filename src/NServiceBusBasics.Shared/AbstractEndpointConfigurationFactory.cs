namespace NServiceBusBasics.Shared;

public abstract class AbstractEndpointConfigurationFactory
{
    private const string RabbitMqConnectionString = "amqp://guest:guest@rabbitmq:5672/";

    private readonly string _endpointName;

    protected AbstractEndpointConfigurationFactory(string endpointName)
    {
        ArgumentException.ThrowIfNullOrEmpty(endpointName);
        _endpointName = endpointName;
    }

    public EndpointConfiguration Create()
    {
        var endpointConfiguration = new EndpointConfiguration(_endpointName);
        ConfigureMessageConventions(endpointConfiguration);
        ConfigureTransport(endpointConfiguration);
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.UseSerialization<NewtonsoftJsonSerializer>();
        return endpointConfiguration;
    }
    
    private void ConfigureTransport(EndpointConfiguration endpointConfiguration)
    {
        var transport = endpointConfiguration.UseTransport<RabbitMQTransport>()
            .ConnectionString(RabbitMqConnectionString)
            .UseConventionalRoutingTopology(QueueType.Classic);
        
        ConfigureTransportSettings(transport);
        ConfigureRouting(transport.Routing());
    }

    protected virtual void ConfigureTransportSettings(TransportExtensions<RabbitMQTransport> transport)
    {
        // override this method to add additional transport settings.
    }
    
    protected virtual void ConfigureRouting(RoutingSettings routingSettings)
    {
        // override this method if you need to configure routing
    }
    
    private static void ConfigureMessageConventions(EndpointConfiguration endpointConfiguration)
    {
        var conventionsBuilder = endpointConfiguration.Conventions();
        conventionsBuilder.DefiningCommandsAs(type => type.Namespace != null && type.Namespace.Contains("Commands"));
        conventionsBuilder.DefiningEventsAs(type => type.Namespace != null && type.Namespace.Contains("Events"));
        conventionsBuilder.DefiningMessagesAs(type => type.Namespace != null && type.Namespace.Contains("Messages"));
    }
}