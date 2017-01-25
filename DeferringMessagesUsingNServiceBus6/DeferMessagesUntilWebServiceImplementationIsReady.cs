using System;
using System.Threading.Tasks;
using DeferringMessagesUsingNServiceBus6.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace DeferringMessagesUsingNServiceBus6
{
    public class DeferMessagesUntilWebServiceImplementationIsReady : IHandleMessages<MessageIWantToDefer>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DeferMessagesUntilWebServiceImplementationIsReady));

        public async Task Handle(MessageIWantToDefer message, IMessageHandlerContext context)
        {
            Log.Warn("Handling MessageIWantToDefer and deferring it for 5 seconds.");

            var options = new SendOptions();
            options.DelayDeliveryWith(new TimeSpan(0, 0, 0, 5));
            options.RouteToThisEndpoint();
            await context.Send(message, options).ConfigureAwait(false);

            context.DoNotContinueDispatchingCurrentMessageToHandlers();
        }
    }
}
