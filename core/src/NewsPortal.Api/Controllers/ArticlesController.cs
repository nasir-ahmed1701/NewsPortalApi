using Microsoft.AspNetCore.Mvc;
using NewsPortal.Business.IServices;
using NewsPortal.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace NewsPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<PaginationResult<Article>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<PaginationResult<Article>>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultBase))]
        public async Task<IActionResult> GetAllArticlesAsync(
            [FromBody, Required] GetAllArticlesRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var response = await _articleService.GetAllArticlesAsync(request, cancellationToken);

                return response.IsSuccessfull
                    ? Ok(response)
                    : BadRequest(response);
            }
            catch (Exception ex)
            {
                var result = new ResultBase([ex.Message]);
                return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Article>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<Article>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultBase))]
        public async Task<IActionResult> GetArticleAsync(
            [FromRoute, Required] int id,
            CancellationToken cancellationToken)
        {
            try
            {
                var response = await _articleService.GetArticleAsync(id, cancellationToken);

                return response.IsSuccessfull
                    ? Ok(response)
                    : NotFound(response);
            }
            catch (Exception ex)
            {
                var result = new ResultBase([ex.Message]);
                return StatusCode(500, result);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Result<int?>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<int?>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultBase))]
        public async Task<IActionResult> CreateArticleAsync(
            [FromBody, Required] CreateArticleRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _articleService.CreateArticleAsync(request, cancellationToken);

                return result.IsSuccessfull
                    ? CreatedAtAction("GetArticle", new { id = result.Data }, result)
                    : BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = new ResultBase([ex.Message]);
                return StatusCode(500, result);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Article>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<Article>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultBase))]
        public async Task<IActionResult> UpdateArticleAsync([FromRoute, Required] int id,
            [FromBody, Required] UpdateArticleRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _articleService.UpdateArticleAsync(id, request, cancellationToken);

                return result.IsSuccessfull
                    ? Ok(result)
                    : BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = new ResultBase([ex.Message]);
                return StatusCode(500, result);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultBase))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultBase))]
        public async Task<IActionResult> DeleteArticleAsync([FromRoute, Required] int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _articleService.DeleteArticleAsync(id, cancellationToken);

                return result.IsSuccessfull
                    ? NoContent()
                    : BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = new ResultBase([ex.Message]);
                return StatusCode(500, result);
            }
        }
    }
}
