using AutoMapper;
using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Extension;
using PaintSystemAPIVersionOne.Model;
using PaintSystemAPIVersionOne.Repositories;

namespace PaintSystemAPIVersionOne.Services;

public class PaintProductStockService
{
    private readonly PaintStockRepository _paintStockRepository;
    private readonly IMapper _mapper;
    public PaintProductStockService(PaintStockRepository paintStockRepository,IMapper mapper)
    {
        _paintStockRepository = paintStockRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all paint product stock entries.
    /// </summary>
    /// <returns>
    /// A <see cref="ServiceResponse{T}"/> containing a list of <see cref="PaintProductsStock"/> 
    /// and status information.
    /// </returns>
    public async Task<ServiceResponse<List<PaintProductsStock>>> GetAllPaintProductsStock()
    {
        //var response = new ServiceResponse<List<PaintProductsStock>>();

        try
        {
            var stocks = await _paintStockRepository.GetAllPaintProductsStock();

            if (stocks.Count == 0)
            {
                return new ServiceResponse<List<PaintProductsStock>>(false, "No Stocks no found", null);
            }

            return new ServiceResponse<List<PaintProductsStock>>(true, "Stocks retrieved successfully", stocks);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<PaintProductsStock>>(false,
                $"Failed to retrieve paint products: {ex.Message}", null);
        }
    }

    /// <summary>
    /// 异步根据库存 ID 获取对应的 PaintProductsStock 信息。
    /// </summary>
    /// <param name="id">要查询的库存 ID。</param>
    /// <returns>
    /// 返回一个 <see cref="ServiceResponse{T}"/> 对象：  
    /// - 如果找到对应库存，<c>IsSuccess</c> 为 <c>true</c>，<c>Data</c> 包含库存信息；  
    /// - 如果未找到，<c>IsSuccess</c> 为 <c>false</c>，<c>Data</c> 为 <c>null</c>，并携带错误消息。
    /// </returns>
    public async Task<ServiceResponse<PaintProductsStock>> GetPaintProductsStockById(int id)
    {
        PaintProductsStock? newStock = await _paintStockRepository.GetPaintProductsStockById(id);

        if (newStock is null)
        {
            return new ServiceResponse<PaintProductsStock>(false, $"No stock found with ID {id}.", null);
        }

        return new ServiceResponse<PaintProductsStock>(true, "Stock retrieved successfully.", newStock);
    }
    
    
    
    /// <summary>
    /// 异步添加新的库存记录。
    /// </summary>
    /// <param name="StockRequest">包含 PaintProductId 和 StockQuantity 的请求对象。</param>
    /// <returns>返回包含新增库存信息的 ServiceResponse 对象。</returns>
    public async Task<ServiceResponse<PaintProductsStock>> AddPaintProductsStock(PaintProductStockRequest StockRequest)
    {

        
       // var paintProduct = _mapper.Map<PaintProduct>(paintProductRequest);
        // var newStock = new PaintProductsStock
        // {
        //     StockQuantity = StockRequest.stockQuantity,
        //     PaintProductId = StockRequest.paintProductId,
        //     CreatedAt = DateTime.Now // 自动设置创建时间
        // };
        
        var newStock= _mapper.Map<PaintProductsStock>(StockRequest);
        
        try
        {
            await _paintStockRepository.AddPaintProductsStock(newStock);
            return new ServiceResponse<PaintProductsStock>(true, "Stock added successfully", newStock);
        }
        catch (Exception e)
        {
            // 出现异常返回失败响应
            return new ServiceResponse<PaintProductsStock>(false, $"Failed to add stock Service: {e.Message}", null);
        }
    }
}