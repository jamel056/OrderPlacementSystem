using Microsoft.AspNetCore.Mvc;
using O.Common;
using O.Core.OrderModule.Requests;
using O.Core.OrderModule.Services;
using OrderSystem.DTO;
using System.Threading.Tasks;

namespace OrderSystem.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Route(Routes.Orders.Place)]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderRequest request)
        {
            var order = await _orderService.PlaceOrder(request);
            var orderFromDb = await _orderService.GetOrder(order.Id);
            var response = new OrdersDTO(orderFromDb);
            return Ok(response);
        }

        [Route(Routes.Orders.Edit)]
        [HttpPut]
        public async Task<IActionResult> EditOrder([FromBody] OrderRequest request, [FromRoute] int id)
        {
            var orderFromDb = await _orderService.GetNoTrackingAsync(id);
            if (orderFromDb == null) return NotFound();

            var orderAfterEdit = await _orderService.EditOrder(request, id);

            var newOrder = await _orderService.GetOrder(orderAfterEdit.Id);
            var response = new OrdersDTO(newOrder);
            return Ok(response);
        }

        [Route(Routes.Orders.Delete)]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var isDeleted = await _orderService.DeleteOrder(id);

            return Ok(new { IsDeleted = isDeleted });
        }

        [Route(Routes.Orders.Find)]
        [HttpGet]
        public async Task<IActionResult> FindOrder([FromRoute] int id)
        {
            var orderFromDb = await _orderService.GetOrder(id);
            if (orderFromDb == null) return NotFound();
            var response = new OrdersDTO(orderFromDb);
            return Ok(response);
        }

        [Route(Routes.Orders.FindByName)]
        [HttpGet]
        public async Task<IActionResult> FindOrder([FromQuery] string name)
        {
            var orderFromDb = await _orderService.GetOrder(name);
            if (orderFromDb == null) return NotFound();
            var response = new OrdersDTO(orderFromDb);
            return Ok(response);
        }
    }
}
