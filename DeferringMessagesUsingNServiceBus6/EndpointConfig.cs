using NServiceBus;

namespace DeferringMessagesUsingNServiceBus6
{
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(EndpointConfiguration endpointConfiguration)
        {
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.AuditProcessedMessagesTo("audit");
            endpointConfiguration.ExecuteTheseHandlersFirst(typeof(DeferMessagesUntilWebServiceImplementationIsReady));
        }
    }
}
