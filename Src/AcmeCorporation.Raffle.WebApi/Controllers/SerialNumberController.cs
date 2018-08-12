using System.Threading.Tasks;
using AcmeCorporation.Raffle.Domain;
using AcmeCorporation.Raffle.Domain.Interfaces;
using AcmeCorporation.Raffle.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace AcmeCorporation.Raffle.WebApi.Controllers
{
    [Route("serials")]
    public class SerialNumberController : ControllerBase
    {
        private readonly ISerialNumberRepository _serialNumberRepository;

        public SerialNumberController(ISerialNumberRepository serialNumberRepository)
        {
            _serialNumberRepository = serialNumberRepository;
        }
        
        [HttpGet, Route("{serialNumber}/validate")]
        public async Task<IActionResult> Validate(string serialNumber)
        {
            var model = await _serialNumberRepository.GetSerialNumber(serialNumber);

            if (TryValidateForUsage(model, out var errorMessage))
            {
                return new OkObjectResult(SerialNumberValidationDto.Success());
            }
            
            return new OkObjectResult(SerialNumberValidationDto.FailedWithError(errorMessage));
        }

        private static bool TryValidateForUsage(SerialNumber model, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (model == null)
            {
                errorMessage = "Could not find the serial number provided.";
                return false;
            }

            if (model.CanBeUsed() == false)
            {
                errorMessage = $"Serial number provided cannot be used, because it has already been used {model.UsageCount} times.";
                return false;
            }

            return true;
        }
    }
}