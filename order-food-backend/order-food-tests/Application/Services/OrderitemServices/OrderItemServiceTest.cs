using Moq;
using order_food_backend.Repositories.Interfaces;
using order_food_backend.Services;
using OrderFoodLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order_food_tests.Application.Services.OrderitemServices
{
    public class OrderItemServiceTest
    {
        private readonly Mock<IOrderItemRepository> _orderItemRepositoryMock;
        private readonly OrderItemService _orderItemService;

        public OrderItemServiceTest()
        {
            _orderItemRepositoryMock = new Mock<IOrderItemRepository>();
            _orderItemService = new OrderItemService(_orderItemRepositoryMock.Object);
        }

        [Fact]
        public async Task GetOrderItems_ShouldReturnOrderItems()
        {
            var items = new List<OrderItem>
            {
            new OrderItem { Id = 1, Quantity = 2, UnitPrice = 10 },
            new OrderItem { Id = 2, Quantity = 1, UnitPrice = 20 }
        };

            _orderItemRepositoryMock.Setup(repo => repo.GetAllOrderItemsAsync()).ReturnsAsync(items);

            var result = await _orderItemService.GetOrderItems();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(2, result.First().Quantity);
        }

        [Fact]
        public async Task GetOrderItemById_ShouldReturnItemById()
        {
            var item = new OrderItem { Id = 1, Quantity = 3, UnitPrice = 15 };

            _orderItemRepositoryMock.Setup(repo => repo.GetOrderItemByIdAsync(1)).ReturnsAsync(item);

            var result = await _orderItemService.GetOrderItemById(1);

            Assert.NotNull(result);
            Assert.Equal(3, result.Quantity);
        }

        [Fact]
        public async Task AddOrderItem_ShouldCallRepository()
        {
            var item = new OrderItem { Id = 1, Quantity = 1, UnitPrice = 10 };

            await _orderItemService.AddOrderItem(item);

            _orderItemRepositoryMock.Verify(repo => repo.CreateOrderItem(item), Times.Once);
        }

        [Fact]
        public async Task UpdateOrderItem_ShouldCallRepository()
        {
            var item = new OrderItem { Id = 1, Quantity = 2, UnitPrice = 12 };

            await _orderItemService.UpdateOrderItem(item.Id, item);

            _orderItemRepositoryMock.Verify(repo => repo.UpdateOrderItem(item), Times.Once);
        }

        [Fact]
        public async Task DeleteOrderItem_ShouldCallRepository()
        {
            int itemId = 1;

            await _orderItemService.DeleteOrderItem(itemId);

            _orderItemRepositoryMock.Verify(repo => repo.DeleteOrderItem(itemId), Times.Once);
        }
    }

}
