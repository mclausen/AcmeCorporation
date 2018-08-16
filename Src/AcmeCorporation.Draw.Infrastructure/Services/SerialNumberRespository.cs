using System.Threading.Tasks;
using AcmeCorporation.Raffle.Domain;
using AcmeCorporation.Raffle.Domain.Interfaces;
using AcmeCorporation.Raffle.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.Raffle.Infrastructure.Services
{
    public class SerialNumberRespository : ISerialNumberRepository
    {
        private readonly DrawDbContext _context;

        public SerialNumberRespository(DrawDbContext context)
        {
            _context = context;
        }
        
        public async Task<SerialNumber> GetSerialNumber(string serialNumber)
        {
            var model = await _context.SerialNumbers.SingleOrDefaultAsync(x => x.Serial.Equals(serialNumber));
            return model;
        }
    }
}