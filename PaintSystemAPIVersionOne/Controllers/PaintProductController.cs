using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Exceptions;
using PaintSystemAPIVersionOne.Model;
using PaintSystemAPIVersionOne.Services;

namespace PaintSystemAPIVersionOne.Controllers
{
    
    [Route("api/PaintProducts")]
    [ApiController]
    public class PaintProductController : ControllerBase
    {
        private readonly PaintProductService _paintProductService;
        
        public PaintProductController(PaintProductService paintProductService)
        {
            _paintProductService = paintProductService;
        }
        
        
        /// <summary>
        /// Get all users to API 
        /// </summary> 
        /// <returns>List of users (Swagger should show the default Datatype) </returns>
        [HttpGet("get-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPaintProduct()
        {
            var products = await _paintProductService.GetAllPaintProduct();
            // 成功返回统一格式
            var response = FormattedResponse<List<PaintProduct>>.Success(products, "PaintProduct retrieved successfully");
            return Ok(response);
        }
        
        
        /// <summary>
        /// get Product by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-product-by-id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaintProductById(int id)
        {
            var product = await _paintProductService.GetProductById(id);
            // 成功返回统一格式
            var response = FormattedResponse<PaintProduct>.Success(product, "PaintProduct found successfully");
            return Ok(response);
        }

        
        
        
        /// <summary>
        /// Get PaintProductRequest and transfer to service layer
        /// </summary>
        /// <param name="paintProductRequest"></param>
        /// <returns></returns>
        [HttpPost("add-product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProduct([FromBody] PaintProductRequest paintProductRequest)
        {
            // 调用 Service 层
            var paintProduct = await _paintProductService.AddProduct(paintProductRequest);

            // 成功返回统一格式
            var response = FormattedResponse<PaintProduct>.Success(paintProduct, "PaintProduct created successfully");
            return Ok(response);
        }
    }
    
    
    
    
}
