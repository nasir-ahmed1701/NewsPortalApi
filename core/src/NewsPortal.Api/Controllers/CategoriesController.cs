using Microsoft.AspNetCore.Mvc;
using NewsPortal.Business.IServices;
using NewsPortal.Business.Models;

namespace NewsPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<IEnumerable<Category>>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultBase))]
        public async Task<IActionResult> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _categoryService.GetAllCategoriesAsync(cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new ResultBase([ex.Message]);
                return StatusCode(500, result);
            }
        }
    }
}
