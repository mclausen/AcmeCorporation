using System;
using System.Linq;
using System.Threading.Tasks;
using AcmeCorporation.Draw.Domain;
using AcmeCorporation.Draw.Domain.Events;
using AcmeCorporation.Draw.Domain.Interfaces;
using AcmeCorporation.Draw.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.Draw.Infrastructure.Services
{
    public class DrawSubmissionService : IDrawSubmissionService
    {
        private readonly DrawDbContext _dbContext;
        private readonly IEventDispatcher eventDispatcher;

        public DrawSubmissionService(DrawDbContext dbContext, IEventDispatcher eventDispatcher)
        {
            _dbContext = dbContext;
            this.eventDispatcher = eventDispatcher;
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
            await _dbContext.DrawSubmissions.AddAsync(submission);

            eventDispatcher.EnqueueDomainEvent(new DrawSubmissionRetrievedDomainEvent(submission.Id, emailAddress.Value));

            return submission;
        }

        public async Task<PagedDrawSubmissionsResult> GetSubmissions(int page = 1)
        {
            const int resultsPrPage = 10; // Should be put in configuration
            var numberOfSubmissions = _dbContext.DrawSubmissions.Count();

            var numberOfPages = (int) Math.Ceiling(numberOfSubmissions / (double)resultsPrPage);
            var skip = resultsPrPage * page;

            var submissions = await _dbContext.DrawSubmissions
                .Include(x => x.SerialNumber)
                .AsNoTracking()
                .OrderBy(x => x.SubmissionTimeUtc)
                .Skip(skip)
                .Take(resultsPrPage)
                .ToListAsync();

            return new PagedDrawSubmissionsResult(numberOfPages, page, submissions);
        }
    }
}