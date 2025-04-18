using Microsoft.EntityFrameworkCore;
using order_food_backend.Context;
using order_food_backend.Repositories.Interfaces;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderItem(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderItem(int id)
        {
            var item = await _context.OrderItems.FindAsync(id);
            if (item == null)
                throw new KeyNotFoundException("Item do pedido não encontrado");

            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _context.OrderItems
                .Include(oi => oi.Dish)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await _context.OrderItems
                .Include(oi => oi.Dish)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateOrderItem(OrderItem orderItem)
        {
            var existing = await _context.OrderItems.FindAsync(orderItem.Id);
            if (existing == null)
                throw new KeyNotFoundException("Item do pedido não encontrado");

            existing.UnitPrice = orderItem.UnitPrice;
            existing.Quantity = orderItem.Quantity;
            existing.Dish = orderItem.Dish;

            await _context.SaveChangesAsync();
        }
    }
}
