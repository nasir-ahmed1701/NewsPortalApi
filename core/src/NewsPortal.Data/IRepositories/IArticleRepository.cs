using NewsPortal.Data.Entities;
using NewsPortal.Data.Models;

namespace NewsPortal.Data.IRepositories
{
    public interface IArticleRepository
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
        Task<(int, IEnumerable<ArticleEntity>)> GetAllArticlesAsync(GetAllArticlesDto filter);
        Task<ArticleEntity?> GetArticleAsync(int id);
        Task<ArticleEntity> CreateArticleAsync(ArticleEntity entity);
        void DeleteArticle(ArticleEntity entity);
    }
}
