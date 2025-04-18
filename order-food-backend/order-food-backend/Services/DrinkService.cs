using order_food_backend.Repositories.Interfaces;
using order_food_backend.Services.Interfaces;
using OrderFoodLibrary.Entities;


namespace order_food_backend.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository _repository;

        public DrinkService(IDrinkRepository repository)
        {
            _repository = repository;
        }

        public async Task AddDrink(Drink drink)
        {
            await _repository.CreateDrink(drink);
        }

        public async Task DeleteDrink(int id)
        {

            if (id == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");
            }
            await _repository.DeleteDrink(id);
        }

        public async Task<IEnumerable<Drink>> GetDrinks()
        {
            IEnumerable<Drink> drinks = await _repository.GetAllDrinksAsync();
            return drinks;
        }

        public async Task<Drink> GetDrinkById(int id)
        {

            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");
            }

            var drink = await _repository.GetDrinkByIdAsync(id);

            if (drink == null)
            {
                throw new KeyNotFoundException($"Nenhuma categoria encontrada para o ID {id}.");
            }

            return drink;
        }

        public async Task UpdateDrink(int id, Drink drink)
        {
            if (drink == null)
            {
                throw new KeyNotFoundException($"Categoria não pode ser null");
            }

            await _repository.UpdateDrink(drink);
        }
    }
}
