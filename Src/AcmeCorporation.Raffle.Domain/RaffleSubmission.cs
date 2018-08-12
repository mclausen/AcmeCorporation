using System;

namespace AcmeCorporation.Raffle.Domain
{
    public class RaffleSubmission
    {
        public int Id { get; set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public EmailAddress EmailAddress { get; protected set; }
        public SerialNumber SerialNumber { get; protected set; }
        public DateTime SubmissionTimeUtc { get; protected set; }


        public RaffleSubmission(string firstName, string lastName, EmailAddress emailAddress, SerialNumber serialNumber)
        {
            if(string.IsNullOrEmpty(firstName)) throw new ArgumentNullException(nameof(firstName));
            if(string.IsNullOrEmpty(lastName)) throw new ArgumentNullException(nameof(lastName));
            if(emailAddress == null) throw new ArgumentNullException(nameof(emailAddress));
            if(serialNumber == null) throw new ArgumentNullException(nameof(serialNumber));
            
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            SerialNumber = serialNumber;
            
            SubmissionTimeUtc = DateTime.UtcNow;
        }
    }
}