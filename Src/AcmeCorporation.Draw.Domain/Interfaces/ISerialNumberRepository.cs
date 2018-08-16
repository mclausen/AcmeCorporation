using System.Threading.Tasks;

namespace AcmeCorporation.Draw.Domain.Interfaces
{
    public interface ISerialNumberRepository
    {
        Task<SerialNumber> GetSerialNumber(string number);
    }
}