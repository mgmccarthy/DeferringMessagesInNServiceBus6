using System.Threading.Tasks;
using DeferringMessagesUsingNServiceBus6.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace DeferringMessagesUsingNServiceBus6
{
    // ReSharper disable once InconsistentNaming
    public class IAlsoHandleMessageIWantToDeferButIWillNeverHandleItAsLongAsItsDeferred : IHandleMessages<MessageIWantToDefer>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(IAlsoHandleMessageIWantToDeferButIWillNeverHandleItAsLongAsItsDeferred));

        public Task Handle(MessageIWantToDefer message, IMessageHandlerContext context)
        {
            Log.Warn("If you're reading this, then something has gone very wrong.");
            return Task.CompletedTask;
        }
    }
}
