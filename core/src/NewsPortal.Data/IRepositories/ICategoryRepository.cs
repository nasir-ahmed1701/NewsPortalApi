using NewsPortal.Data.Entities;

namespace NewsPortal.Data.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
    }
}
