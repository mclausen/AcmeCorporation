using System.Threading.Tasks;

namespace AcmeCorporation.Draw.Domain.Events
{
    /// <summary>
    /// A handling mechanism for published domain events
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IHandleDomainEvent<in TEvent> where TEvent : IDomainEvent
    {
        Task Handle(TEvent @event);
    }
}
