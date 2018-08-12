using System.Threading.Tasks;

namespace AcmeCorporation.Raffle.Domain.Interfaces
{
    public interface ISerialNumberRepository
    {
        Task<SerialNumber> GetSerialNumber(string number);
    }
}