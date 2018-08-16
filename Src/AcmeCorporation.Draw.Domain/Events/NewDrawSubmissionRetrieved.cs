namespace AcmeCorporation.Draw.Domain.Events
{
    public class DrawSubmissionRetrievedDomainEvent : IDomainEvent
    {
        public int SubmissionId { get; protected set; }
        public string EmailAddress { get; protected set; }

        public DrawSubmissionRetrievedDomainEvent(int submissionId, string emailAddress)
        {
            SubmissionId = submissionId;
            EmailAddress = emailAddress;
        }
    }
}
