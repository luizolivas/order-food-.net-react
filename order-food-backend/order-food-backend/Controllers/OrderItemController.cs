using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using order_food_backend.Services.Interfaces;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _service;

        public OrderItemController(IOrderItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> Get()
        {
            var items = await _service.GetOrderItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> Get(int id)
        {
            var item = await _service.GetOrderItemById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderItem orderItem)
        {
            await _service.AddOrderItem(orderItem);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrderItem orderItem)
        {
            if (id != orderItem.Id)
                return BadRequest("ID da URL não corresponde ao ID do corpo");

            await _service.UpdateOrderItem(id, orderItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteOrderItem(id);
            return Ok($"Item do pedido com ID {id} foi deletado com sucesso.");
        }
    }
}
