using OrderFoodLibrary.Entities;

namespace order_food_backend.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetOrderItems();
        Task<OrderItem> GetOrderItemById(int id);
        Task UpdateOrderItem(int id, OrderItem orderItem);
        Task DeleteOrderItem(int id);
        Task AddOrderItem(OrderItem orderItem);
    }
}
