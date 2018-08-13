using System;
using System.Linq;
using System.Threading.Tasks;
using AcmeCorporation.Raffle.Domain;
using AcmeCorporation.Raffle.Domain.Interfaces;
using AcmeCorporation.Raffle.Infrastructure.Services;
using AcmeCorporation.Raffle.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace AcmeCorporation.Raffle.WebApi.Controllers
{
    [Route("submissions")]
    public class RaffleSubmissionsController : ControllerBase
    {
        private readonly IRaffleSubmissionService _submissionService;
        private readonly ISerialNumberRepository _serialNumberRepository;

        public RaffleSubmissionsController(IRaffleSubmissionService submissionService, ISerialNumberRepository serialNumberRepository)
        {
            _submissionService = submissionService;
            _serialNumberRepository = serialNumberRepository;
        }
        
        [HttpGet, Route("{page}")]
        public async Task<IActionResult> Get(int page)
        {
            var pagedResult = await _submissionService.GetSubmissions(page);
            var result = new PagedDrawSubmissionsDto()
            {
                CurrentPage = pagedResult.CurrentPage,
                NumberOfPages = pagedResult.NumberOfPages,
                Submissions = pagedResult.Submissions.Select(x => new DrawSubmissionListingDto()
                {
                    Id = x.Id,
                    EmailAddress = x.EmailAddress.Value,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SerialNumber = x.SerialNumber.Serial,
                    SubmissionTimeUtc = x.SubmissionTimeUtc
                }).ToList()
            };

            return new OkObjectResult(result);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> SubmitDraw([FromBody]SubmitDrawRequest request)
        {
            var serialNumber = await _serialNumberRepository.GetSerialNumber(request.SerialNumber);
            if (serialNumber == null)
                return BadRequest();
    
            var submission = await _submissionService.Submit(request.FirstName, request.LastName, new EmailAddress(request.EmailAddress),
                serialNumber);
 
            return new OkObjectResult(new DrawSubmissionListingDto()
            {
                FirstName = submission.FirstName,
                LastName = submission.LastName,
                EmailAddress = submission.EmailAddress.Value,
                SerialNumber = serialNumber.Serial,
                SubmissionTimeUtc = submission.SubmissionTimeUtc
            });
        }
    }
}