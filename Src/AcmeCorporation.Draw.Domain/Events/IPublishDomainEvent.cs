namespace AcmeCorporation.Draw.Domain.Events
{
    public interface IPublishDomainEvent
    {
        void Publish(IDomainEvent domainEvent);
    }
}
