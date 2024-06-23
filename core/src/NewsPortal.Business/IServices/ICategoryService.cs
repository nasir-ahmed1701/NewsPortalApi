using NewsPortal.Business.Models;

namespace NewsPortal.Business.IServices
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<Category>>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
    }
}
