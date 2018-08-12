namespace AcmeCorporation.Raffle.WebApi.Model
{
    public class PaginationMetaInfoDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public int TotalCount { get; set; }
    }
}