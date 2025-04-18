using OrderFoodLibrary.Entities;

namespace order_food_backend.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderById(int id);
        Task UpdateOrder(int id, Order order);
        Task DeleteOrder(int id);
        Task AddOrder(Order order);
    }
}
