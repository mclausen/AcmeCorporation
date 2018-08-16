using System;

namespace AcmeCorporation.Raffle.WebApi.Model
{
    public class DrawSubmissionListingDto
    {    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string SerialNumber { get; set; }
        public DateTime SubmissionTimeUtc { get; set; }
    }
}