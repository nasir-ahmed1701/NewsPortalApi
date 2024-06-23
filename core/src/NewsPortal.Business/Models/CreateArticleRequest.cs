namespace NewsPortal.Business.Models
{
    public record CreateArticleRequest(string Title, int CategoryId, string Description)
    {
    }
}
