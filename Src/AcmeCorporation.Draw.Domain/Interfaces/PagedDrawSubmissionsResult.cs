using System.Collections.Generic;

namespace AcmeCorporation.Draw.Domain.Interfaces
{
    public class PagedDrawSubmissionsResult
    {
        public int NumberOfPages { get; protected set; }
        public int CurrentPage { get; protected set; }
        public List<DrawSubmission> Submissions { get; protected set; }

        public PagedDrawSubmissionsResult(int numberOfPages, int currentPage, List<DrawSubmission> submissions)
        {
            NumberOfPages = numberOfPages;
            CurrentPage = currentPage;
            Submissions = submissions;
        }
    }
}