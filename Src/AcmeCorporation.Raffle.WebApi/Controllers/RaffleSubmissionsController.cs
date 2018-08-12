using System;
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
        
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get([FromQuery]int skip, [FromQuery]int take)
        {
            return new OkResult();
        }
        
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return new OkResult();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitDraw([FromBody]SubmitDrawRequest request)
        {
            var serialNumber = await _serialNumberRepository.GetSerialNumber(request.SerialNumber);
            if (serialNumber == null)
                return BadRequest();
    
            var submission = await _submissionService.Submit(request.FirstName, request.LastName, new EmailAddress(request.EmailAddress),
                serialNumber);
 
            return new CreatedAtRouteResult(nameof(GetById), new { id = submission.Id} ,new DrawSubmissionListingDto()
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