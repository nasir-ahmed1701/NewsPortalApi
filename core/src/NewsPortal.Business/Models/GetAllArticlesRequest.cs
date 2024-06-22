namespace NewsPortal.Business.Models
{
    public class GetAllArticlesRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchText { get; set; }
    }
}
