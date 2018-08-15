using System;
using System.Linq;
using AcmeCorporation.Raffle.Domain;
using AcmeCorporation.Raffle.Domain.Interfaces;
using AcmeCorporation.Raffle.WebApi.Model;

namespace AcmeCorporation.Raffle.WebApi.Extensions
{
    public static class DtoExtensions
    {
        public static DrawSubmissionListingDto ToDto(this RaffleSubmission self, bool includeSerial = false)
        {
            return new DrawSubmissionListingDto()
            {
                Id = self.Id,
                EmailAddress = self.EmailAddress.Value,
                FirstName = self.FirstName,
                LastName = self.LastName,
                SerialNumber = includeSerial ? self.SerialNumber.Serial : string.Empty,
                SubmissionTimeUtc = self.SubmissionTimeUtc
            };
        }

        public static PagedDrawSubmissionsDto ToDto(this PagedDrawSubmissionsResult self)
        {
            return new PagedDrawSubmissionsDto()
            {
                CurrentPage = self.CurrentPage,
                NumberOfPages = self.NumberOfPages,
                Submissions = self.Submissions
                    .Select(draw => draw.ToDto())
                    .ToList()
            };
        }
    }
}