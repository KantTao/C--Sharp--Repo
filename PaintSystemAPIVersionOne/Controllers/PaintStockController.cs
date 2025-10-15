using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Exceptions;
using PaintSystemAPIVersionOne.Model;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await _paintStockService.GetAllPaintProductsStock();

            // 成功返回统一格式
            var response = FormattedResponse<List<PaintProductsStock>>.Success(stocks, "Stocks retrieved successfully");
            return Ok(response);
        }

        
        
        /// <summary>
        /// 根据库存 ID 获取对应的 PaintProductsStock 信息。
        /// </summary>
        /// <param name="id">库存 ID。</param>
        /// <returns>返回库存详情或统一格式的 JSON。</returns>
        [HttpGet("get-stock/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaintProductsStockById(int id)
        {
            var stock = await _paintStockService.GetPaintProductsStockById(id);

            // 成功返回统一格式
            var response = FormattedResponse<PaintProductsStock>.Success(stock, "Stock retrieved successfully");
            return Ok(response);
        }
        
        
        /// <summary>
        /// 新增库存记录。
        /// </summary>
        /// <param name="stockRequest">包含 PaintProductId 和 StockQuantity 的请求对象。</param>
        /// <returns>返回新增库存信息或失败消息。</returns>
        [HttpPost("add-stock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddStock([FromBody] PaintProductStockRequest stockRequest)
        {
            var newStock = await _paintStockService.AddPaintProductsStock(stockRequest);

            // 成功返回统一格式
            var response = FormattedResponse<PaintProductsStock>.Success(newStock, "Stock added successfully");
            return Ok(response);
        }
    }
}