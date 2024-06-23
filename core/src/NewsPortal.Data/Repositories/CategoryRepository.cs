using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.Entities;
using NewsPortal.Data.IRepositories;

namespace NewsPortal.Data.Repositories
{
    public class CategoryRepository(NewsPortalDbContext dbContext) : ICategoryRepository
    {
        private readonly NewsPortalDbContext _dbContext = dbContext;

        public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Categories
                                   .OrderBy(x => x.Title)
                                   .ToListAsync(cancellationToken);
        }
    }
}
