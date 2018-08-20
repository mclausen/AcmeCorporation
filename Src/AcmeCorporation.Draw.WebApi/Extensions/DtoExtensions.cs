using System;
using System.Linq;
using AcmeCorporation.Draw.Domain;
using AcmeCorporation.Draw.Domain.Interfaces;
using AcmeCorporation.Draw.WebApi.Model;

namespace AcmeCorporation.Draw.WebApi.Extensions
{
    public static class DtoExtensions
    {
        public static DrawSubmissionListingDto ToDto(this DrawSubmission self, bool includeSerial = false)
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
                    .Select(draw => draw.ToDto(true))
                    .ToList()
            };
        }
    }
}
