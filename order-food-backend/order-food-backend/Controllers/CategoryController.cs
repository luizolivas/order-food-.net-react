using Microsoft.AspNetCore.Mvc;
using order_food_backend.Services.Interfaces;
using OrderFoodLibrary.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace order_food_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<categoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var categories = await _categoryService.GetCategories();

            if (categories == null)
            {
                return NotFound("Nenhum prato encontrado");
            }

            return Ok(categories);
        }

        // GET api/<categoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            if (id == 0)
            {
                return NotFound($"Nenhum prato encontrado para ID {id}");
            }
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound("Nenhum prato encontrado");
            }

            return Ok(category);
        }

        // POST api/<categoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("category recebido é igual a null");
            }
            await _categoryService.AddCategory(category);
            return Ok();
        }

        // PUT api/<categoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Category category)
        {
            if (category == null || id <= 0 || id != category.Id)
            {
                return BadRequest($"Dados inválidos. ID na URL: {id}, ID no corpo: {category?.Id}");
            }

            var existingcategory = await _categoryService.GetCategoryById(id);

            if (existingcategory == null)
            {
                return NotFound($"Prato com ID {id} não encontrado.");
            }

            await _categoryService.UpdateCategory(id, category);
            return Ok();
        }

        // DELETE api/<categoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Dados inválidos. ID na URL: {id}");
            }

            var existingcategory = await _categoryService.GetCategoryById(id);

            if (existingcategory == null)
            {
                return NotFound($"Prato com ID {id} não encontrado.");
            }

            await _categoryService.DeleteCategory(id);
            return Ok($"Prato com ID {id} foi deletado com sucesso.");
        }
    }
}
