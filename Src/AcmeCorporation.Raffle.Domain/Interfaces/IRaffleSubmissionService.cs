using System.Threading.Tasks;

namespace AcmeCorporation.Raffle.Domain.Interfaces
{
    public interface IRaffleSubmissionService
    {
        Task Submit(string firstName, string lastname, EmailAddress emailAddress, SerialNumber serialNumber);
    }
}