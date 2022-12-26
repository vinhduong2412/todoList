using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.DTOs;
using Todo.Services;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController (ICategoryService categoryService, ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        [HttpGet("categories")]
        public async Task<ActionResult<CategoryResponseDTO>> GetCategory()
        {
            try
            {
                return Ok(await _categoryService.GetCategory());
            }
            catch
            {
                _logger.LogInformation("Internal Server Error");
                return StatusCode(500);
            }
        }
    }
}
