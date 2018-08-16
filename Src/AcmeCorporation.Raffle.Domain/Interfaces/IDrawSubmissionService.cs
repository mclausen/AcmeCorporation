using System.Threading.Tasks;

namespace AcmeCorporation.Raffle.Domain.Interfaces
{
    public interface IDrawSubmissionService
    {
        Task<DrawSubmission> Submit(string firstName, string lastname, EmailAddress emailAddress, SerialNumber serialNumber);
        Task<PagedDrawSubmissionsResult> GetSubmissions(int page);
    }
}