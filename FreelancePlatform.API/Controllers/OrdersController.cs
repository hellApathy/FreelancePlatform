using FreelancePlatform.BLL.Services;
using FreelancePlatform.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FreelancePlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get() => Ok(_orderService.GetAllOrders());

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            _orderService.AddOrder(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Order order)
        {
            if (id != order.Id) return BadRequest();
            _orderService.UpdateOrder(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}