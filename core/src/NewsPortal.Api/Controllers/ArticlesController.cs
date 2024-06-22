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
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
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
                return StatusCode(500, ex.Message);
            }
        }
    }
}
