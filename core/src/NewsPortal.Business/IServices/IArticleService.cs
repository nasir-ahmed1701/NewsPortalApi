using NewsPortal.Business.Models;

namespace NewsPortal.Business.IServices
{
    public interface IArticleService
    {
        Task<Result<PaginationResult<Article>>> GetAllArticlesAsync(GetAllArticlesRequest filterRequest, CancellationToken cancellationToken = default);
        Task<Result<Article>> GetArticleAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<int?>> CreateArticleAsync(CreateArticleRequest request, CancellationToken cancellationToken = default);
        Task<Result<Article>> UpdateArticleAsync(int id, UpdateArticleRequest request, CancellationToken cancellationToken = default);
        Task<ResultBase> DeleteArticleAsync(int id, CancellationToken cancellationToken = default);
    }
}
