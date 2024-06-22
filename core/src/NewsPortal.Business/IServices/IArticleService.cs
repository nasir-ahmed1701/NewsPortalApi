using NewsPortal.Business.Models;

namespace NewsPortal.Business.IServices
{
    public interface IArticleService
    {
        Task<Result<PaginationResult<Article>>> GetAllArticlesAsync(GetAllArticlesRequest filterRequest);
        Task<Result<Article>> GetArticleAsync(int id);
    }
}
