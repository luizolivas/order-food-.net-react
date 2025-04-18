using Microsoft.EntityFrameworkCore;
using order_food_backend.Context;
using order_food_backend.Repositories.Interfaces;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly ApplicationDbContext _context;

        public DrinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateDrink(Drink drink)
        {
            await _context.Drinks.AddAsync(drink);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDrink(int id)
        {
            var Drink = await _context.Drinks.FindAsync(id);
            if (Drink == null)
            {
                throw new KeyNotFoundException("Bebida não encontrada");
            }

            _context.Drinks.Remove(Drink);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Drink>> GetAllDrinksAsync()
        {
            return await _context.Drinks.AsNoTracking().ToListAsync();
        }

        public async Task<Drink> GetDrinkByIdAsync(int id)
        {
            return await _context.Drinks.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateDrink(Drink drink)
        {
            var existingDrink = await _context.Drinks.FindAsync(drink.Id);

            if (existingDrink == null)
            {
                throw new KeyNotFoundException("Bebida não encontrada");
            }

            existingDrink.Name = drink.Name;
            existingDrink.Alcoholic = drink.Alcoholic;

            await _context.SaveChangesAsync();
        }
    }
}
