using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Services;

namespace PaintSystemAPIVersionOne.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class PaintStockController : ControllerBase
    {
        private readonly PaintProductStockService _paintStockService;


        public PaintStockController(PaintProductStockService paintStockService)
        {
            _paintStockService = paintStockService;
        }
        
        
        /// <summary>
        /// Get all paint stocks.
        /// </summary>
        /// <returns>Returns a list of paint stocks or an error message.</returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllStocks()
        {
            var response = await _paintStockService.GetAllPaintProductsStock();
            if (!response.IsSuccess)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        /// <summary>
        /// 根据库存 ID 获取对应的 PaintProductsStock 信息。
        /// </summary>
        /// <param name="id">库存 ID。</param>
        /// <returns>返回库存详情或错误信息。</returns>
        [HttpGet("get-stock/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaintProductsStockById(int id)
        {
            var response = await _paintStockService.GetPaintProductsStockById(id);

            if (!response.IsSuccess)
                return NotFound(response.Message);
            return Ok(response.Data);
        }


        /// <summary>
        /// 新增库存记录。
        /// </summary>
        /// <param name="stockRequest">包含 PaintProductId 和 StockQuantity 的请求对象。</param>
        /// <returns>返回新增库存信息或失败消息。</returns>
        [HttpPost("add-stock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStock([FromBody] PaintProductStockRequest stockRequest)
        {
            
            // 调用 Service 层添加库存
            var response = await _paintStockService.AddPaintProductsStock(stockRequest);

            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }

            // 成功返回 200 和新增库存对象
            return Ok(response.Data);
        }
    }
}