using OrderFoodLibrary.Entities;

namespace order_food_backend.Repositories.Interfaces
{
    public interface IDrinkRepository
    {
        Task<IEnumerable<Drink>> GetAllDrinksAsync();
        Task<Drink> GetDrinkByIdAsync(int id);
        Task DeleteDrink(int id);
        Task UpdateDrink(Drink drink);
        Task CreateDrink(Drink drink);
    }
}
