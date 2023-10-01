using NServiceBus;
using NServiceBusBasics.Contracts.Commands;
using NServiceBusBasics.Shared;

namespace NServiceBusBasics.Sender;

internal sealed class SenderEndpointConfigurationFactory : AbstractEndpointConfigurationFactory
{
   public SenderEndpointConfigurationFactory() 
      : base("sender")
   {
   }
   
   protected override void ConfigureRouting(RoutingSettings routingSettings)
   {
      base.ConfigureRouting(routingSettings);
      
      routingSettings.RouteToEndpoint(
         assembly: typeof(CreateOrder).Assembly,
         destination: "receiver");
   }
}