using System;
using System.Threading.Tasks;
using DeferringMessagesUsingNServiceBus6.Messages;
using NServiceBus;

namespace DeferringMessagesUsingNServiceBus6.ClassClient
{
    public class MessageSender : IWantToRunWhenEndpointStartsAndStops
    {
        public async Task Start(IMessageSession session)
        {
            Console.WriteLine("Press 'Enter' to send MessageIWantToDefer");
            while (Console.ReadLine() != null)
            {
                await session.Send(new MessageIWantToDefer());
            }
        }

        public Task Stop(IMessageSession session)
        {
            return Task.CompletedTask;
        }
    }
}
