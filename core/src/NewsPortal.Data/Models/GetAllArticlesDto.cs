namespace NewsPortal.Data.Models
{
    public class GetAllArticlesDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchText { get; set; }
    }
}
