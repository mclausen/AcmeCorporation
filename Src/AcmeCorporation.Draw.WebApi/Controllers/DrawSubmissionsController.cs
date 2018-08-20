using System.Threading.Tasks;
using AcmeCorporation.Draw.Domain;
using AcmeCorporation.Draw.Domain.Interfaces;
using AcmeCorporation.Draw.WebApi.Extensions;
using AcmeCorporation.Draw.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace AcmeCorporation.Draw.WebApi.Controllers
{
    [Route("submissions")]
    public class DrawSubmissionsController : ControllerBase
    {
        private readonly IDrawSubmissionService _submissionService;
        private readonly ISerialNumberRepository _serialNumberRepository;

        public DrawSubmissionsController(IDrawSubmissionService submissionService, ISerialNumberRepository serialNumberRepository)
        {
            _submissionService = submissionService;
            _serialNumberRepository = serialNumberRepository;
        }
        
        // [Authorize] if security was enabled this wouldnt be commented out
        [HttpGet, Route("pages/{page}")] // /pages/to avoid defacto rest getbyId convention
        public async Task<IActionResult> Get(int page)
        {
            var pagedResult = await _submissionService.GetSubmissions(page);
            var dto = pagedResult.ToDto();

            return new OkObjectResult(dto);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> SubmitDraw([FromBody]SubmitDrawRequest request)
        {
            var serialNumber = await _serialNumberRepository.GetSerialNumber(request.SerialNumber);
            if (serialNumber == null)
                return BadRequest();
    
            var submission = await _submissionService.Submit(request.FirstName, request.LastName, new EmailAddress(request.EmailAddress),
                serialNumber);

            var dto = submission.ToDto(includeSerial: true);
            return new OkObjectResult(dto);
        }
    }
}
