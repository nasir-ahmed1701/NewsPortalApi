using FluentValidation;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAllArticles([FromBody, Required] GetAllArticlesRequest request)
        {
            try
            {
                var response = await _articleService.GetAllArticlesAsync(request);

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
        public async Task<IActionResult> GetArticle([FromRoute, Required] int id)
        {
            try
            {
                var response = await _articleService.GetArticleAsync(id);

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
        public async Task<IActionResult> CreateArticle([FromBody, Required] CreateArticleRequest request)
        {
            try
            {
                var result = await _articleService.CreateArticleAsync(request);

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
        public async Task<IActionResult> UpdateArticle([FromRoute, Required] int id, [FromBody, Required] UpdateArticleRequest request)
        {
            try
            {
                var result = await _articleService.UpdateArticleAsync(id, request);

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
        public async Task<IActionResult> DeleteArticle([FromRoute, Required] int id)
        {
            try
            {
                var result = await _articleService.DeleteArticleAsync(id);

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
