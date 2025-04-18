using OrderFoodLibrary.Entities;

namespace order_food_backend.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task DeleteOrder(int id);
        Task UpdateOrder(Order order);
        Task CreateOrder(Order order);
        Task UpdateStatusOrder(int orderId);
    }
}
