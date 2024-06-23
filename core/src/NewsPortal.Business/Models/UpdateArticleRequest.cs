namespace NewsPortal.Business.Models
{
    public record UpdateArticleRequest(string Title, int CategoryId, string Description)
    {
    }
}
