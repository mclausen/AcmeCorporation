using System;
using System.Linq;
using System.Threading.Tasks;
using AcmeCorporation.Raffle.Domain;
using AcmeCorporation.Raffle.Domain.Interfaces;
using AcmeCorporation.Raffle.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.Raffle.Infrastructure.Services
{
    public class DrawSubmissionService : IDrawSubmissionService
    {
        private readonly DrawDbContext _dbContext;

        public DrawSubmissionService(DrawDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<DrawSubmission> Submit(string firstName, string lastname, EmailAddress emailAddress, SerialNumber serialNumber)
        {
            if (serialNumber == null) throw new ArgumentNullException(nameof(serialNumber));
            
            serialNumber.Use();
            
            var submission = new DrawSubmission(
                firstName: firstName, 
                lastName: lastname, 
                emailAddress: emailAddress,
                serialNumber: serialNumber);
            await _dbContext.RaffleSubmissions.AddAsync(submission);

            return submission;
        }

        public async Task<PagedDrawSubmissionsResult> GetSubmissions(int page = 1)
        {
            const int resultsPrPage = 10; // Should be put in configuration
            var numberOfSubmissions = _dbContext.RaffleSubmissions.Count();

            var numberOfPages = (int) Math.Ceiling(numberOfSubmissions / (double)resultsPrPage);
            var skip = resultsPrPage * page;

            var submissions = await _dbContext.RaffleSubmissions
                .Include(x => x.SerialNumber)
                .OrderBy(x => x.SubmissionTimeUtc)
                .Skip(skip)
                .Take(resultsPrPage)
                .ToListAsync();

            return new PagedDrawSubmissionsResult(numberOfPages, page, submissions);
        }
    }
}