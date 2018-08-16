using System;

namespace AcmeCorporation.Draw.Domain
{
    public class SerialNumber
    {
        public string Serial { get; protected set; }
        public DateTime DateCreatedUtc { get; protected set; }
        public int UsageCount { get; protected set; }


        public bool CanBeUsed()
        {
            return UsageCount < 2;
        }

        public void Use()
        {
            if (CanBeUsed())
            {
                UsageCount++; 
                return;
            }

            throw new DomainException($"Serial number '{Serial}' exeeded its usage count");
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