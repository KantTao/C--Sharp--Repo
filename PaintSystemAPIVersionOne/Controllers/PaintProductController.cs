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
        /// <returns>List of users </returns>
        [HttpGet("get-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<PaintProduct>>> GetAllPaintProduct()
        {
            var response = await _PaintProductService.GetAllPaintProduct();
            
            if (!response.IsSuccess) return BadRequest(response.Message);
            return response.Data;

            
        }

    }
    


    
    
}
