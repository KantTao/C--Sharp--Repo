using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintSystemAPIVersionOne.Model;
using PaintSystemAPIVersionOne.Services;

namespace PaintSystemAPIVersionOne.Controllers
{
    
    [Route("api/PaintProducts")]
    [ApiController]
    public class PaintProductController : ControllerBase
    {
        
        private readonly PaintProductService _PaintProductService;

        public PaintProductController(PaintProductService PaintProductService)
        {
            _PaintProductService = PaintProductService;
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
            var response = await _PaintProductService.GetAllPaintProduct();
            
            if (!response.IsSuccess) return BadRequest(response.Message);
            return Ok(response.Data);
        }
        
        
        [HttpGet("get-Product-by-Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPaintProductById(int id)
        {
            var response = await _PaintProductService.GetProductById(id);
            if (!response.IsSuccess) return BadRequest(response.Message);
            return Ok(response.Data);
        }


    }
    


    
    
}
