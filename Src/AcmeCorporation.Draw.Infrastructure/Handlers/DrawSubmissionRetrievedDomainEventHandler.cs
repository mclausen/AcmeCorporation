using AcmeCorporation.Draw.Domain.Events;
using System.Threading.Tasks;

namespace AcmeCorporation.Draw.Infrastructure.Handlers
{
    public class DrawSubmissionRetrievedDomainEventHandler : IHandleDomainEvent<DrawSubmissionRetrievedDomainEvent>
    {
        public Task Handle(DrawSubmissionRetrievedDomainEvent @event)
        {
            // Here i would sent an receipt email to a user
            // The work could easily be offloaded to a background worker, by putting a message on an message bus and then sent it to a generic email handler

            return Task.CompletedTask;
        }
    }
}
