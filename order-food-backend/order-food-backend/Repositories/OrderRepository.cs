using Microsoft.EntityFrameworkCore;
using order_food_backend.Context;
using order_food_backend.Repositories.Interfaces;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                throw new KeyNotFoundException("pedido não encontrado");

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatusOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
