using OrderFoodLibrary.Entities;

namespace order_food_backend.Services.Interfaces
{
    public interface IDrinkService
    {
        Task<IEnumerable<Drink>> GetDrinks();
        Task<Drink> GetDrinkById(int id);
        Task UpdateDrink(int id, Drink Drink);
        Task DeleteDrink(int id);
        Task AddDrink(Drink Drink);
    }
}
