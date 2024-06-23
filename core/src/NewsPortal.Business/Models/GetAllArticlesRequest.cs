namespace NewsPortal.Business.Models
{
    public record GetAllArticlesRequest(int PageNumber, int PageSize, string? SearchText)
    {
    }
}
