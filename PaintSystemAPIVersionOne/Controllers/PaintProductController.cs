using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintSystemAPIVersionOne.DTO;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<PaintProduct>>> GetAllPaintProduct()
        {
            var response = await _paintProductService.GetAllPaintProduct();
            
            if (!response.IsSuccess) return BadRequest(response.Message);
            return Ok(response.Data);
        }
        
        /// <summary>
        /// get Product by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-Product-by-Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPaintProductById(int id)
        {
            var response = await _paintProductService.GetProductById(id);
            if (!response.IsSuccess) return BadRequest(response.Message);
            return Ok(response.Data);
        }

        
        
        /// <summary>
        /// Get PaintProductRequest and transfer to service layer
        /// </summary>
        /// <param name="paintProductRequest"></param>
        /// <returns></returns>
        [HttpPost("add-Product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProduct([FromBody]PaintProductRequest paintProductRequest)
        {
            
            // 调用服务层方法
            var result = await _paintProductService.AddProduct(paintProductRequest);

            if (!result.IsSuccess)
                return BadRequest(result.Message); // 校验失败或ID错误
            return Ok(result.Data); // 创建成功，返回新对象
        }
    }
    
    
    
    
}
