using System;
using System.Linq;
using System.Threading.Tasks;
using AcmeCorporation.Raffle.Domain;
using AcmeCorporation.Raffle.Domain.Interfaces;
using AcmeCorporation.Raffle.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.Raffle.Infrastructure.Services
{
    public class RaffleSubmissionService : IRaffleSubmissionService
    {
        private readonly RaffleDbContext _dbContext;

        public RaffleSubmissionService(RaffleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<RaffleSubmission> Submit(string firstName, string lastname, EmailAddress emailAddress, SerialNumber serialNumber)
        {
            if (serialNumber == null) throw new ArgumentNullException(nameof(serialNumber));
            
            serialNumber.Use();
            
            var submission = new RaffleSubmission(
                firstName: firstName, 
                lastName: lastname, 
                emailAddress: emailAddress,
                serialNumber: serialNumber);
            await _dbContext.RaffleSubmissions.AddAsync(submission);

            return submission;
        }

        public async Task<PagedRaffleSubmissionsResult> GetSubmissions(int page = 1)
        {
            const int resultsPrPage = 10;
            var numberOfSubmissions = _dbContext.RaffleSubmissions.Count();

            var numberOfPages = (int) Math.Ceiling(numberOfSubmissions / (double)resultsPrPage);
            var skip = resultsPrPage * page;

            var submissions = await _dbContext.RaffleSubmissions
                .Include(x => x.SerialNumber)
                .Skip(skip)
                .Take(resultsPrPage)
                .OrderBy(x => x.SubmissionTimeUtc)
                .ToListAsync();

            return new PagedRaffleSubmissionsResult(numberOfPages, page, submissions);
        }
    }
}