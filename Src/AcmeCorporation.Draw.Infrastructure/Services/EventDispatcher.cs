using AcmeCorporation.Draw.Domain.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeCorporation.Draw.Infrastructure.Services
{
    public class EventDispatcher : IEventDispatcher, IPublishDomainEvent
    {
        private readonly IServiceProvider serviceProvider;

        public List<IDomainEvent> events;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            events = new List<IDomainEvent>();
        }

        public async Task DispatchEvents()
        {
            foreach(var @event in events)
            {
                var type = @event.GetType();
                var handlerType = typeof(IHandleDomainEvent<>).MakeGenericType(type);

                var handler = serviceProvider.GetService(handlerType); // should have a GetServices, to allow for more handlers that subscribes to same events
                if (handler == null) continue;

                await (Task)handler.GetType()
                    .GetMethod("Handle")
                    .Invoke(handler, new object[] { @event });
            }

            events.Clear();
        }

        public void Publish(IDomainEvent domainEvent)
        {
            if (domainEvent == null)
                throw new ArgumentNullException(nameof(domainEvent));

            events.Add(domainEvent);
        }
    }
}
