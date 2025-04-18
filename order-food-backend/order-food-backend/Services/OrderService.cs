using order_food_backend.Repositories.Interfaces;
using order_food_backend.Services.Interfaces;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task AddOrder(Order order)
        {
            await _repository.CreateOrder(order);
        }

        public async Task DeleteOrder(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");

            await _repository.DeleteOrder(id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _repository.GetAllOrdersAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");

            var order  = await _repository.GetOrderByIdAsync(id);
            if (order == null)
                throw new KeyNotFoundException($"Nenhum  de pedido encontrado com ID {id}.");

            return order;
        }

        public async Task UpdateOrder(int id, Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), " do pedido não pode ser null");

            if (order.Id != id)
                throw new ArgumentException("ID do corpo não corresponde ao da URL");

            await _repository.UpdateOrder(order);
        }
    }
}
