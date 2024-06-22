using AutoMapper;
using FluentValidation;
using NewsPortal.Business.IServices;
using NewsPortal.Business.Models;
using NewsPortal.Data.IRepositories;
using NewsPortal.Data.Models;

namespace NewsPortal.Business.Services
{
    public class ArticleService(
        IArticleRepository articleRepository,
        IMapper mapper,
        IValidator<GetAllArticlesRequest> getAllArticlesRequestValdiator) : IArticleService
    {
        private readonly IArticleRepository _articleRepository = articleRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<GetAllArticlesRequest> _getAllArticlesRequestValdiator = getAllArticlesRequestValdiator;

        public async Task<Result<PaginationResult<Article>>> GetAllArticlesAsync(GetAllArticlesRequest getAllArticlesRequest)
        {
            var validationResult = await _getAllArticlesRequestValdiator.ValidateAsync(getAllArticlesRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage);
                return new Result<PaginationResult<Article>>(errors: errors, data: null);
            }

            var getAllArticlesDto = _mapper.Map<GetAllArticlesDto>(getAllArticlesRequest);

            var result = await _articleRepository.GetAllArticlesAsync(getAllArticlesDto);

            var articles = _mapper.Map<IEnumerable<Article>>(result.Item2);

            var paginationResult = new PaginationResult<Article>(
                totalCount: result.Item1,
                currentPageNumber: getAllArticlesDto.PageNumber,
                currentPageSize: getAllArticlesDto.PageSize,
                items: articles);

            return new Result<PaginationResult<Article>>(errors: null, data: paginationResult);
        }

        public async Task<Result<Article>> GetArticleAsync(int id)
        {
            if (id <= 0)
            {
                var errors = new string[] { "id must be greater than 0" };
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
    }
}
