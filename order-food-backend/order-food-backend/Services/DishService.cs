using order_food_backend.Repositories.Interfaces;
using order_food_backend.Services.Interfaces;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Services
{
    public class DishService : IDishService
    {

        private readonly IDishRepository _dishRepository;

        public DishService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public async Task AddDish(Dish dish)
        {
            await _dishRepository.CreateDish(dish);
        }

        public async Task DeleteDish(int id)
        {

            if (id == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");
            }
            await _dishRepository.DeleteDish(id);
        }

        public async Task<IEnumerable<Dish>> GetDishes()
        {
            IEnumerable<Dish> dishes = await _dishRepository.GetAllDishesAsync();
            return dishes;
        }

        public async Task<Dish> GetDishById(int id)
        {

            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");
            }

            var dish = await _dishRepository.GetDishByIdAsync(id);

            if (dish == null)
            {
                throw new KeyNotFoundException($"Nenhuma prato encontrada para o ID {id}.");
            }

            return dish;
        }

        public async Task UpdateDish(int id, Dish dish)
        {
            if (dish == null)
                throw new ArgumentNullException(nameof(dish), "Prato não pode ser null");

            if (dish.Id != id)
                throw new ArgumentException("O ID do prato informado não corresponde ao ID do objeto.");

            await _dishRepository.UpdateDish(dish);
        }
    }
}
