using System.Collections.Generic;

namespace AcmeCorporation.Raffle.WebApi.Model
{
    public class PagedDrawSubmissionsDto
    {
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public List<DrawSubmissionListingDto> Submissions { get; set; }

        public PagedDrawSubmissionsDto()
        {
            Submissions = new List<DrawSubmissionListingDto>();
        }
    }
}