using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Enum;
using PaintSystemAPIVersionOne.Extension;
using PaintSystemAPIVersionOne.Model;
using PaintSystemAPIVersionOne.Services;

namespace PaintSystemAPIVersionOne.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
        
        
        /// <summary>
        /// Get all orders to API 
        /// </summary>
        /// <returns>List of orders </returns>
        [HttpGet("get-all-orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var response = await _orderService.GetAllOrders();
            if (!response.IsSuccess) return BadRequest(response.Message);

            return response.Data;
        }
        
        
        
        /// <summary>
        /// Retrieves an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier (ID) of the order to retrieve.</param>
        /// <returns>
        /// Returns a 200 OK response with the order data if found; 
        /// otherwise, returns a 400 Bad Request with an error message.
        /// </returns>
        [HttpGet("get-order-by-id/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _orderService.GetOrderById(id);

            if (!response.IsSuccess)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }
        
        
        
        /// <summary>
        /// Add a new order
        /// </summary>
        /// <param name="request">Order creation request from the front-end</param>
        /// <returns>Returns the created order or an error message</returns>
        [HttpPost("add-order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOrder([FromBody] OrderCreateRequest request)
        {
            // 调用 Service 层
            var response = await _orderService.AddOrder(request);
            
            if (!response.IsSuccess)
                return BadRequest(response.Message); // 返回 400 和错误信息

            return Ok(response.Data); // 返回 200 和新建的订单
        }
        
        
        /// <summary>
        /// Deletes an order by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the order to delete.</param>
        /// <returns>
        /// Returns 200 OK with the deleted order if successful;
        /// otherwise, returns 400 Bad Request with an error message.
        /// </returns>
        [HttpDelete("delete-order/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            // 调用 Service 层删除订单
            var response = await _orderService.DeleteOrderById(id);

            // 如果失败，返回 400
            if (!response.IsSuccess)
                return BadRequest(response.Message);

            // 成功返回 200 和被删除的订单
            return Ok(response.Data);
        }
    }
    
}