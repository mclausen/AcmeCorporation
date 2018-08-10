using System;

namespace AcmeCorporation.Raffle.Domain
{
    public class SerialNumber
    {
        public string Serial { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public int UsageCount { get; set; }
    }
}