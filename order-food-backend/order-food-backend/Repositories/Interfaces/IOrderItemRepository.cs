using OrderFoodLibrary.Entities;

namespace order_food_backend.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task DeleteOrderItem(int id);
        Task UpdateOrderItem(OrderItem orderItem);
        Task CreateOrderItem(OrderItem orderItem);
    }
}
