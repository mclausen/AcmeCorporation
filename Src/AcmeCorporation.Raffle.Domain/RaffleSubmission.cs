using System;

namespace AcmeCorporation.Raffle.Domain
{
    public class RaffleSubmission
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmailAddress EmailAddress { get; set; }
        public SerialNumber SerialNumber { get; set; }
        public DateTime SubmissionTimeUtc { get; set; }
    }
}