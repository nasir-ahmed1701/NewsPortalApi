using NewsPortal.Business.Models;

namespace NewsPortal.Business.IServices
{
    public interface IArticleService
    {
        Task<Result<PaginationResult<Article>>> GetAllArticlesAsync(GetAllArticlesRequest filterRequest);
        Task<Result<Article>> GetArticleAsync(int id);
        Task<Result<int?>> CreateArticleAsync(CreateArticleRequest request);
        Task<Result<Article>> UpdateArticleAsync(int id, UpdateArticleRequest request);
        Task<ResultBase> DeleteArticleAsync(int id);
    }
}
