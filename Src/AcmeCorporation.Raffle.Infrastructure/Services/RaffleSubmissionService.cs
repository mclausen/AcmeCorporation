using System;
using System.Threading.Tasks;
using AcmeCorporation.Raffle.Domain;
using AcmeCorporation.Raffle.Domain.Interfaces;
using AcmeCorporation.Raffle.Infrastructure.Storage;

namespace AcmeCorporation.Raffle.Infrastructure.Services
{
    public class RaffleSubmissionService : IRaffleSubmissionService
    {
        private readonly RaffleDbContext _dbContext;

        public RaffleSubmissionService(RaffleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task Submit(string firstName, string lastname, EmailAddress emailAddress, SerialNumber serialNumber)
        {
            if (serialNumber == null) throw new ArgumentNullException(nameof(serialNumber));
            
            serialNumber.Use();
            
            var submission = new RaffleSubmission(
                firstName: firstName, 
                lastName: lastname, 
                emailAddress: emailAddress,
                serialNumber: serialNumber);
            await _dbContext.RaffleSubmissions.AddAsync(submission);
        }
    }
}