using Microsoft.AspNetCore.Mvc;
using order_food_backend.Services.Interfaces;
using OrderFoodLibrary.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace order_food_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }



        // GET: api/<DrinkController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            var drinks = await _drinkService.GetDrinks();

            if (drinks == null)
            {
                return NotFound("Nenhuma bebida encontrado");
            }

            return Ok(drinks);
        }

        // GET api/<DrinkController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound($"Nenhuma bebida encontrado para ID {id}");
            }
            var drink = await _drinkService.GetDrinkById(id);

            if (drink == null)
            {
                return NotFound("Nenhuma bebida encontrado");
            }

            return Ok(drink);
        }

        // POST api/<DrinkController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Drink drink)
        {
            if (drink == null)
            {
                return BadRequest("Drink recebido é igual a null");
            }
            await _drinkService.AddDrink(drink);
            return Ok();
        }

        // PUT api/<DrinkController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Drink drink)
        {
            if (drink == null || id <= 0 || id != drink.Id)
            {
                return BadRequest($"Dados inválidos. ID na URL: {id}, ID no corpo: {drink?.Id}");
            }

            var existingDrink = await _drinkService.GetDrinkById(id);

            if (existingDrink == null)
            {
                return NotFound($"Bebida com ID {id} não encontrado.");
            }

            await _drinkService.UpdateDrink(id, drink);
            return Ok();
        }

        // DELETE api/<DrinkController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Dados inválidos. ID na URL: {id}");
            }

            var existingDrink = await _drinkService.GetDrinkById(id);

            if (existingDrink == null)
            {
                return NotFound($"Bebida com ID {id} não encontrado.");
            }

            await _drinkService.DeleteDrink(id);
            return Ok($"Bebida com ID {id} foi deletado com sucesso.");
        }
    }
}
