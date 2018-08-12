using System;
using System.Threading.Tasks;
using AcmeCorporation.Raffle.Domain;
using AcmeCorporation.Raffle.Domain.Interfaces;
using AcmeCorporation.Raffle.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AcmeCorporation.Raffle.Tests.Integration.Services
{
    [TestFixture]
    public class RaffleSubmissionServiceTests : DbTestFixture
    {
        private IRaffleSubmissionService sut;
        
        public override void DoSetup()
        {
            sut = new RaffleSubmissionService(Context);
        }

        [Test]
        public async Task Submit_SerialNumberIsNull_Throws()
        {
            Assert.ThrowsAsync<ArgumentNullException>(()
                => sut.Submit(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                    new EmailAddress("aValid@email.com"), null));
        }

        [Test]
        public async Task Submit_Succeeds()
        {
            // Arrange
            var serial = Guid.NewGuid().ToString();
            var serialNumber = SerialNumber.CreateNewSerialNumber(serial);
            
            var firstName = Guid.NewGuid().ToString();
            var lastName = Guid.NewGuid().ToString();
            var emailAddress = $"{Guid.NewGuid().ToString()}@{Guid.NewGuid().ToString()}.com";

            // Act
            await sut.Submit(firstName, lastName, new EmailAddress(emailAddress), serialNumber);
            await Context.SaveChangesAsync();
            
            
            // Assert
            var submission = await Context.RaffleSubmissions
                .Include(x => x.SerialNumber) // Loads the adjacent entity to only roundtrip the database once
                .SingleOrDefaultAsync();
            Assert.NotNull(submission);
            
            Assert.That(submission.FirstName, Is.EqualTo(firstName));
            Assert.That(submission.LastName, Is.EqualTo(lastName));
            Assert.That(submission.EmailAddress.Value, Is.EqualTo(emailAddress));
            
            Assert.That(submission.SerialNumber.UsageCount, Is.EqualTo(1));
            
        }
        
    }
}