using System.Collections.Generic;

namespace AcmeCorporation.Raffle.Domain.Interfaces
{
    public class PagedRaffleSubmissionsResult
    {
        public int NumberOfPages { get; protected set; }
        public int CurrentPage { get; protected set; }
        public List<RaffleSubmission> Submissions { get; protected set; }

        public PagedRaffleSubmissionsResult(int numberOfPages, int currentPage, List<RaffleSubmission> submissions)
        {
            NumberOfPages = numberOfPages;
            CurrentPage = currentPage;
            Submissions = submissions;
        }
    }
}