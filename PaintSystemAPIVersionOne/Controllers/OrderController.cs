using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Enum;
using PaintSystemAPIVersionOne.Exceptions;
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
            var order = await _orderService.AddOrder(request);
            // 成功统一返回 FormattedResponse
            var response = FormattedResponse<Order>.Success(order, "Order added successfully");
            return Ok(response);
            
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
            var deletedOrder = await _orderService.DeleteOrderById(id);

            // 成功统一返回 FormattedResponse
            var response = FormattedResponse<Order>.Success(deletedOrder, "Order deleted successfully");
            
            // 成功返回 200 和被删除的订单
            return Ok(response);
        }
    }
    
}