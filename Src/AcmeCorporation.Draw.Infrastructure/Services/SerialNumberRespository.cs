using System.Threading.Tasks;
using AcmeCorporation.Draw.Domain;
using AcmeCorporation.Draw.Domain.Interfaces;
using AcmeCorporation.Draw.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.Draw.Infrastructure.Services
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
            var model = await _context.SerialNumbers
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Serial.Equals(serialNumber));
            return model;
        }
    }
}