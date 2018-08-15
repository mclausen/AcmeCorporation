using System.Collections.Generic;

namespace AcmeCorporation.Raffle.Domain.Interfaces
{
    public class PagedDrawSubmissionsResult
    {
        public int NumberOfPages { get; protected set; }
        public int CurrentPage { get; protected set; }
        public List<RaffleSubmission> Submissions { get; protected set; }

        public PagedDrawSubmissionsResult(int numberOfPages, int currentPage, List<RaffleSubmission> submissions)
        {
            NumberOfPages = numberOfPages;
            CurrentPage = currentPage;
            Submissions = submissions;
        }
    }
}