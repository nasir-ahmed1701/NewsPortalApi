using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.Entities;
using NewsPortal.Data.IRepositories;
using NewsPortal.Data.Models;

namespace NewsPortal.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly NewsPortalDbContext _dbContext;

        public ArticleRepository(NewsPortalDbContext dbContext) => _dbContext = dbContext;

        #region Public Methods

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<(int, IEnumerable<ArticleEntity>)> GetAllArticlesAsync(GetAllArticlesDto filter)
        {
            var query = _dbContext.Articles.Include(x => x.Category).AsQueryable();

            query = ApplyFilters(query, filter.SearchText!);

            var totalCount = await query.CountAsync();

            List<ArticleEntity> result = [];

            if (totalCount > 0)
            {
                query = ApplyOrdering(query);

                query = ApplyPagination(query, filter.PageNumber, filter.PageSize);

                result = await query.ToListAsync();
            }

            return (totalCount, result);
        }

        public async Task<ArticleEntity?> GetArticleAsync(int id)
        {
            var entity = await _dbContext.Articles
                  .Include(x => x.Category)
                  .FirstOrDefaultAsync(x => x.Id == id);

            return entity;

        }
        public async Task<ArticleEntity> CreateArticleAsync(ArticleEntity entity)
        {
            await _dbContext.Articles.AddAsync(entity);
            return entity;
        }

        public void DeleteArticle(ArticleEntity entity)
        {
            _dbContext.Articles.Remove(entity);
        }
        #endregion

        #region Private Methods
        private IQueryable<ArticleEntity> ApplyFilters(IQueryable<ArticleEntity> query, string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(x =>
                   x.Title.Contains(searchText) ||
                   x.Category.Title.Contains(searchText) ||
                   x.Description.Contains(searchText));
            }

            return query;
        }

        private IQueryable<ArticleEntity> ApplyOrdering(IQueryable<ArticleEntity> query)
        {
            query = query.OrderByDescending(x => x.CreatedDateTimeUtc);
            return query;
        }

        private IQueryable<ArticleEntity> ApplyPagination(IQueryable<ArticleEntity> query, int pageNumber, int pageSize)
        {
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return query;
        }
        #endregion


    }
}
