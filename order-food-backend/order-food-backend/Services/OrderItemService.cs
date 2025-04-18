using order_food_backend.Repositories.Interfaces;
using order_food_backend.Services.Interfaces;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;

        public OrderItemService(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task AddOrderItem(OrderItem orderItem)
        {
            await _repository.CreateOrderItem(orderItem);
        }

        public async Task DeleteOrderItem(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");

            await _repository.DeleteOrderItem(id);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems()
        {
            return await _repository.GetAllOrderItemsAsync();
        }

        public async Task<OrderItem> GetOrderItemById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");

            var item = await _repository.GetOrderItemByIdAsync(id);
            if (item == null)
                throw new KeyNotFoundException($"Nenhum item de pedido encontrado com ID {id}.");

            return item;
        }

        public async Task UpdateOrderItem(int id, OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem), "Item do pedido não pode ser null");

            if (orderItem.Id != id)
                throw new ArgumentException("ID do corpo não corresponde ao da URL");

            await _repository.UpdateOrderItem(orderItem);
        }
    }
}
