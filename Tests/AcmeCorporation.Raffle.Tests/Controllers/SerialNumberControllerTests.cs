using System;
using System.Threading.Tasks;
using AcmeCorporation.Raffle.Domain;
using AcmeCorporation.Raffle.Domain.Interfaces;
using AcmeCorporation.Raffle.WebApi.Controllers;
using AcmeCorporation.Raffle.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AcmeCorporation.Raffle.Tests.Controllers
{
    [TestFixture]
    public class SerialNumberControllerTests
    {
        private SerialNumberController sut;
        private Mock<ISerialNumberRepository> serialNumberRepositoryMock;

        [SetUp]
        public void Setup()
        {
            serialNumberRepositoryMock = new Mock<ISerialNumberRepository>();
            sut = new SerialNumberController(serialNumberRepositoryMock.Object);
        }

        [Test]
        public async Task Validate_NoSerialFound_ReturnsFailedResult()
        {
            var serialNumber = Guid.NewGuid().ToString();
            serialNumberRepositoryMock.Setup(x => x.GetSerialNumber(serialNumber))
                .ReturnsAsync(() => null);

            var response = await sut.Validate(serialNumber);
            Assert.IsInstanceOf<OkObjectResult>(response);

            var payload = UnWrapResponse(response);
            Assert.IsFalse(payload.IsValid);
        }
        
        [Test]
        public async Task Validate_ExeededLimit_ReturnsFailedResult()
        {
            var serialNumber = Guid.NewGuid().ToString();
            serialNumberRepositoryMock.Setup(x => x.GetSerialNumber(serialNumber))
                .ReturnsAsync(() =>
                {
                    var serial = SerialNumber.CreateNewSerialNumber(serialNumber);
                    serial.Use();
                    serial.Use();
                    return serial;
                });

            var response = await sut.Validate(serialNumber);
            Assert.IsInstanceOf<OkObjectResult>(response);

            var payload = UnWrapResponse(response);
            Assert.IsFalse(payload.IsValid);
        }
        
        [Test]
        public async Task Validate_ValidSerial_ReturnsSuccess()
        {
            var serialNumber = Guid.NewGuid().ToString();
            serialNumberRepositoryMock.Setup(x => x.GetSerialNumber(serialNumber))
                .ReturnsAsync(() => SerialNumber.CreateNewSerialNumber(serialNumber));

            var response = await sut.Validate(serialNumber);
            Assert.IsInstanceOf<OkObjectResult>(response);

            var payload = UnWrapResponse(response);
            Assert.IsTrue(payload.IsValid);
        }

        private SerialNumberValidationDto UnWrapResponse(IActionResult result)
        {
            var payload = (result as OkObjectResult).Value;
            var typedPayLoad = payload as SerialNumberValidationDto;
            return typedPayLoad;
        }
    }
}