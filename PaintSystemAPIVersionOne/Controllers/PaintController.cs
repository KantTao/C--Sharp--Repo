using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaintSystemAPIVersionOne.Data;
using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    //可以从Controllers 可以调用_dbContext的数据从数据库，从而返回前段接口？
    public class PaintController : ControllerBase
    {
        private PaintDbContext _dbContext;

        public PaintController(PaintDbContext context)
        {
            _dbContext = context;
        }
        

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var users = _dbContext.UserTable.ToList();
            return Ok(users);
        }
    
        [HttpGet("orders")]
        public IActionResult GetAllOrders()
        {
            var orders = _dbContext.OrderTable.ToList();
            return Ok(orders);
        }
        
        

        [HttpGet("paintProduct")]
        public IActionResult GetAllPaintProduct()
        {
            var PaintProducts = _dbContext.PaintProductTable
                .ToList();
            return Ok(PaintProducts);
        }


        [HttpGet("paintProduct/{id}")]
        public IActionResult GetPaintProductById(int id)
        {
            var paintProduct = _dbContext.PaintProductTable
                .FirstOrDefault(p => p.Id == id); // 根据id查找，不Include任何导航属性

            if (paintProduct == null)
            {
                return NotFound($"No PaintProduct found with Id = {id}");
            }

            return Ok(paintProduct);
        }


        // POST api/paint/paintProduct
        [HttpPost("paintProduct")]
        public IActionResult CreatePaintProduct([FromBody] PaintProduct paintProduct)
        {
            if (paintProduct == null)
            {
                return BadRequest("PaintProduct is null");
            }

            
            var newPaintProduct = new PaintProduct(
                paintProduct.Name,
                paintProduct.PricePerLitre,
                paintProduct.Color,
                paintProduct.GlossLevel,
                paintProduct.BaseType,
                paintProduct.Size,
                paintProduct.Stock
            )

            {
                // 通过对象初始化器设置其他字段
                PaintBrandId = paintProduct.PaintBrandId,
                PaintSeriesId = paintProduct.PaintSeriesId,
                PaintCategoryId = paintProduct.PaintCategoryId,
                CreatedAt = DateTime.Now // 如果你想覆盖构造函数里面的 CreatedAt
            };
            _dbContext.PaintProductTable.Add(newPaintProduct);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetPaintProductById), new { id = newPaintProduct.Id }, newPaintProduct);
        }


        [HttpGet("PaintProductsStock")]
        public IActionResult GetAllPaintProductsStock()
        {
            var PaintProductsStocks = _dbContext.PaintProductsStockTable.ToList()
                .ToList();
            return Ok(PaintProductsStocks);
        }
        
        
        
        [HttpGet("PaintProductsStock/{id}")]
        public IActionResult PaintProductsStockById(int id)
        {
            var PaintProductsStock = _dbContext.PaintProductsStockTable
                .FirstOrDefault(p => p.Id == id); // 根据id查找，不Include任何导航属性

            if (PaintProductsStock == null)
            {
                return NotFound($"No PaintProductsStock found with Id = {id}");
            }
            
            return Ok(PaintProductsStock);
        }
        
        [HttpPost("paintProductStock")]
        public IActionResult CreatePaintProductStock([FromBody] PaintProductsStock paintProductsStock)
        {
            if (paintProductsStock == null)
            {
                return BadRequest("paintProductsStock is null");
            }

            // 创建新对象，避免直接操作前端传入对象
            var newStock = new PaintProductsStock
            {
                StockQuantity = paintProductsStock.StockQuantity,
                PaintProductId = paintProductsStock.PaintProductId,
                CreatedAt = DateTime.Now // 自动设置创建时间
            };

            _dbContext.PaintProductsStockTable.Add(newStock);
            _dbContext.SaveChanges();

            // 返回新创建的对象信息
            return Ok(newStock);
        }

        
        
        [HttpGet("orders/{id}")]
        public IActionResult GetAllOrderById(int id)
        {
                var orders = _dbContext.OrderTable
                  .FirstOrDefault(p => p.Id == id); // 根据id查找，不Include任何导航属性
            return Ok(orders);
        }
        
        
        
        [HttpPost("order")]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            
            if (order == null)
                return BadRequest("Order is null");
            // 检查 User 是否存在
            var userExists = _dbContext.UserTable.Any(u => u.Id == order.UserId);
            if (!userExists)
                return BadRequest($"UserId {order.UserId} does not exist.");
            // 只插入 Order 自身字段，不处理导航属性
            var newOrder = new Order
            {   
                TotalPrice = order.TotalPrice,
                OrderStatus = order.OrderStatus,
                OrderReference = order.OrderReference,
                UserId = order.UserId,
                CreatedAt = DateTime.Now
            };
            
            
            _dbContext.OrderTable.Add(newOrder);
            _dbContext.SaveChanges();
            // 关闭 IDENTITY_INSERT
    
            return Ok(newOrder); // 返回新创建的 Order 对象，包括生成的 Id
        }
        
        
        
        [HttpDelete("order/{id}")]
        public IActionResult CancelOrder(int id)
        {
            var order = _dbContext.OrderTable.Find(id);
            if (order == null)
                return NotFound();

            _dbContext.OrderTable.Remove(order);
            _dbContext.SaveChanges();   // ✅ 返回200 + 消息
            return Ok(new { message = "Delete successful", deletedOrderId = id });
        }
        
    }



}