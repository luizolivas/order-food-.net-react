using Microsoft.AspNetCore.Mvc;
using order_food_backend.Services.Interfaces;
using OrderFoodLibrary.DTOs;
using OrderFoodLibrary.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace order_food_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {

        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        // GET: api/<DishController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            var dishes = await _dishService.GetDishes();

            if (dishes == null)
            {
                return NotFound("Nenhum prato encontrado");
            }

            return Ok(dishes);
        }

        // GET api/<DishController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound($"Nenhum prato encontrado para ID {id}");
            }
            var dish = await _dishService.GetDishById(id);

            if (dish == null)
            {
                return NotFound("Nenhum prato encontrado");
            }

            return Ok(dish);
        }

        // POST api/<DishController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DishDto dish)
        {
            if (dish == null)
            {
                return BadRequest("Dish recebido é igual a null");
            }
            await _dishService.AddDish(dish);
            return Ok();
        }

        // PUT api/<DishController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Dish dish)
        {
            if (dish == null || id <= 0 || id != dish.Id)
            {
                return BadRequest($"Dados inválidos. ID na URL: {id}, ID no corpo: {dish?.Id}");
            }

            var existingDish = await _dishService.GetDishById(id);

            if (existingDish == null)
            {
                return NotFound($"Prato com ID {id} não encontrado.");
            }

            await _dishService.UpdateDish(id, dish);
            return Ok();
        }

        // DELETE api/<DishController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Dados inválidos. ID na URL: {id}");
            }

            var existingDish = await _dishService.GetDishById(id);

            if (existingDish == null)
            {
                return NotFound($"Prato com ID {id} não encontrado.");
            }

            await _dishService.DeleteDish(id);
            return Ok($"Prato com ID {id} foi deletado com sucesso.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAvailability(int id, bool avaliable)
        {
            if (id <= 0)
            {
                return BadRequest($"ID inválido. ID: {id}.");
            }

            var updatedDish = await _dishService.UpdateAviability(id, avaliable);
            return Ok(updatedDish);
        }
    }
}
