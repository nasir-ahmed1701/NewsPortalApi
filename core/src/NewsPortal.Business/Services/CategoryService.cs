using AutoMapper;
using NewsPortal.Business.IServices;
using NewsPortal.Business.Models;
using NewsPortal.Data.IRepositories;

namespace NewsPortal.Business.Services
{
    public class CategoryService(
        ICategoryRepository categoryRepository,
        IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<IEnumerable<Category>>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categoryEntities = await _categoryRepository.GetAllCategoriesAsync(cancellationToken);

            var categories = _mapper.Map<IEnumerable<Category>>(categoryEntities);

            return new Result<IEnumerable<Category>>(errors: null, data: categories ?? []);
        }
    }
}
