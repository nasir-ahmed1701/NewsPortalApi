using NewsPortal.Data.Entities;
using NewsPortal.Data.Models;

namespace NewsPortal.Data.IRepositories
{
    public interface IArticleRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        Task<(int, IEnumerable<ArticleEntity>)> GetAllArticlesAsync(GetAllArticlesDto filter, CancellationToken cancellationToken = default);
        Task<ArticleEntity?> GetArticleAsync(int id, CancellationToken cancellationToken = default);
        Task<ArticleEntity> CreateArticleAsync(ArticleEntity entity, CancellationToken cancellationToken = default);
        void DeleteArticle(ArticleEntity entity);
    }
}
