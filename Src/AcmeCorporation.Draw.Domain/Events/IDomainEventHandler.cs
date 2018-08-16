using System.Threading.Tasks;

namespace AcmeCorporation.Draw.Domain.Events
{
    public interface IHandleDomainEvent<in TEvent> where TEvent : IDomainEvent
    {
        Task Handle(TEvent @event);
    }
}
