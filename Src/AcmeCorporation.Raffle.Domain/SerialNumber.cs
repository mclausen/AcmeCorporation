using System;

namespace AcmeCorporation.Raffle.Domain
{
    public class SerialNumber
    {
        // Could be added to column for flexibility
        private const int NumberOfUsages = 2;
        
        public string Serial { get; protected set; }
        public DateTime DateCreatedUtc { get; protected set; }
        public int UsageCount { get; protected set; }
        public bool CanBeUsed => UsageCount <= NumberOfUsages;
        

        public void Use()
        {
            if (CanBeUsed)
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