using Microsoft.AspNetCore.Mvc;
using OrderBinSizingWebApi.Application.Dto;
using OrderBinSizingWebApi.Application.Interfaces;

namespace OrderBinSizingWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {

            _orderService = orderService;
        }


        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(int orderId)
        {
            var order = await _orderService.GetOrderAsync(orderId);
            return order is null ? NotFound() : Ok(order);            
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder([FromBody] OrderDto order)
        {
            try
            {
                await _orderService.SubmitOrderAsync(order);
                return CreatedAtAction(nameof(Get), new { orderId = order.Id }, order);
            }
            catch (Exception)
            {
                return BadRequest("invalid data");
            }           
            
        }
                
    }
}
