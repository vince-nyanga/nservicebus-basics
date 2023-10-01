using NServiceBusBasics.Shared;

namespace NServiceBusBasics.Spy;

internal sealed class SpyEndpointConfigurationFactory : AbstractEndpointConfigurationFactory
{
    public SpyEndpointConfigurationFactory()
        : base("spy")
    {
    }
}