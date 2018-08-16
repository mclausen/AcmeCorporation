using System.Threading.Tasks;

namespace AcmeCorporation.Draw.Domain.Events
{
    public interface IEventDispatcher
    {
        void EnqueueDomainEvent(IDomainEvent domainEvent);
        Task DispatchEvents();
    }
}
