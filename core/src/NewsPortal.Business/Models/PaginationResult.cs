namespace NewsPortal.Business.Models
{
    public class PaginationResult<T>(int totalCount, int currentPageNumber, int currentPageSize, IEnumerable<T> items)
    {
        public int TotalCount { get; set; } = totalCount;
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((TotalCount / (double)CurrentPageSize));
            }
        }
        public int CurrentPageNumber { get; set; } = currentPageNumber;
        public int CurrentPageSize { get; set; } = currentPageSize;
        public IEnumerable<T> Items { get; set; } = items;
    }
}
