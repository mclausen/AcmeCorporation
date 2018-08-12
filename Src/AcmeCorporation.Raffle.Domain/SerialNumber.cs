using System;

namespace AcmeCorporation.Raffle.Domain
{
    public class SerialNumber
    {   
        public string Serial { get; protected set; }
        public DateTime DateCreatedUtc { get; protected set; }
        public int UsageCount { get; protected set; }

        public void Use()
        {
            if (UsageCount == 2)
            {
                throw new DomainException($"Serial number '{Serial}' exeeded its usage count");
            }

            UsageCount++;
        }

        public static SerialNumber CreateNewSerialNumber(string serialNumber)
        {
            return new SerialNumber
            {
                DateCreatedUtc = DateTime.Now,
                Serial = serialNumber,
                UsageCount = 0
            };
        }
    }
}