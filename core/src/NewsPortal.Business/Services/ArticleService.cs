using AutoMapper;
using FluentValidation;
using NewsPortal.Business.IServices;
using NewsPortal.Business.Models;
using NewsPortal.Data.Entities;
using NewsPortal.Data.IRepositories;
using NewsPortal.Data.Models;

namespace NewsPortal.Business.Services
{
    public class ArticleService(
        IArticleRepository articleRepository,
        IMapper mapper,
        IValidator<GetAllArticlesRequest> getAllArticlesRequestValdiator,
        IValidator<CreateArticleRequest> createArticleRequestValidator,
        IValidator<UpdateArticleRequest> updateArticleRequestValidator) : IArticleService
    {
        private readonly IArticleRepository _articleRepository = articleRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<GetAllArticlesRequest> _getAllArticlesRequestValdiator = getAllArticlesRequestValdiator;

        public async Task<Result<PaginationResult<Article>>> GetAllArticlesAsync(GetAllArticlesRequest getAllArticlesRequest, CancellationToken cancellationToken = default)
        {
            var validationResult = await _getAllArticlesRequestValdiator.ValidateAsync(getAllArticlesRequest, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage);
                return new Result<PaginationResult<Article>>(errors: errors, data: null);
            }

            var getAllArticlesDto = _mapper.Map<GetAllArticlesDto>(getAllArticlesRequest);

            var result = await _articleRepository.GetAllArticlesAsync(getAllArticlesDto, cancellationToken);

            var articles = _mapper.Map<IEnumerable<Article>>(result.Item2);

            var paginationResult = new PaginationResult<Article>(
                totalCount: result.Item1,
                currentPageNumber: getAllArticlesDto.PageNumber,
                currentPageSize: getAllArticlesDto.PageSize,
                items: articles);

            return new Result<PaginationResult<Article>>(errors: null, data: paginationResult);
        }

        public async Task<Result<Article>> GetArticleAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
            {
                var errors = new string[] { "Id must be greater than 0" };
                return new Result<Article>(errors: errors, data: null);
            }

            var result = await _articleRepository.GetArticleAsync(id);

            if (result is null)
            {
                var errors = new string[] { $"Article not found for the id {id}" };
                return new Result<Article>(errors: errors, data: null);
            }

            var article = _mapper.Map<Article>(result);

            return new Result<Article>(errors: null, data: article);
        }

        public async Task<Result<int?>> CreateArticleAsync(CreateArticleRequest request, CancellationToken cancellationToken = default)
        {
            var validationResult = await createArticleRequestValidator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage);
                return new Result<int?>(errors: errors, data: null);
            }

            var createEntity = _mapper.Map<ArticleEntity>(request);

            createEntity.CreatedDateTimeUtc = DateTime.UtcNow;

            var result = await _articleRepository.CreateArticleAsync(createEntity, cancellationToken);

            await _articleRepository.SaveChangesAsync(cancellationToken);

            return new Result<int?>(errors: null, data: result.Id);
        }

        public async Task<Result<Article>> UpdateArticleAsync(int id, UpdateArticleRequest request, CancellationToken cancellationToken = default)
        {
            var validationResult = await updateArticleRequestValidator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage);
                return new Result<Article>(errors: errors, data: null);
            }

            var existingEntity = await _articleRepository.GetArticleAsync(id, cancellationToken);

            if (existingEntity is null)
            {
                var errors = new string[] { $"Article not found for the id {id}" };
                return new Result<Article>(errors: errors, data: null);
            }

            existingEntity.Title = request.Title;
            existingEntity.Description = request.Description;
            existingEntity.CategoryId = request.CategoryId;

            await _articleRepository.SaveChangesAsync(cancellationToken);

            var result = await GetArticleAsync(existingEntity.Id, cancellationToken);

            return result;
        }

        public async Task<ResultBase> DeleteArticleAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
            {
                var errors = new string[] { $"Id must be greater than 0" };
                return new Result<int?>(errors: errors, data: null);
            }

            var existingEntity = await _articleRepository.GetArticleAsync(id, cancellationToken);

            if (existingEntity is null)
            {
                var errors = new string[] { $"Article not found for the id {id}" };
                return new Result<int?>(errors: errors, data: null);
            }

            _articleRepository.DeleteArticle(existingEntity);

            await _articleRepository.SaveChangesAsync(cancellationToken);

            return new ResultBase(errors: null);
        }
    }
}
