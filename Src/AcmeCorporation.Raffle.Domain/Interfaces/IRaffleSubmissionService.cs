using System.Threading.Tasks;

namespace AcmeCorporation.Raffle.Domain.Interfaces
{
    public interface IRaffleSubmissionService
    {
        Task<RaffleSubmission> Submit(string firstName, string lastname, EmailAddress emailAddress, SerialNumber serialNumber);
        Task<PagedRaffleSubmissionsResult> GetSubmissions(int page = 1);
    }
}