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
    public async Task<List<PaintProductsStock>>  GetAllPaintProductsStock()
    {
        //var response = new ServiceResponse<List<PaintProductsStock>>();
        var stocks = await _paintStockRepository.GetAllPaintProductsStock();
        if (stocks == null || stocks.Count == 0)
            // 数据为空，抛异常由 Middleware 捕获并返回统一格式
            throw new KeyNotFoundException("No Stocks found");
        return stocks; // 成功返回实体列表
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
    
    
    public async Task<PaintProductsStock> GetPaintProductsStockById(int id)
    {
        var stock = await _paintStockRepository.GetPaintProductsStockById(id);

        if (stock == null)
            // 找不到数据，抛异常，由 Middleware 捕获并返回统一格式
            throw new KeyNotFoundException($"No stock found with ID {id}.");

        return stock; // 成功返回实体
    }
    
    
    
    /// <summary>
    /// 异步添加新的库存记录。
    /// </summary>
    /// <param name="StockRequest">包含 PaintProductId 和 StockQuantity 的请求对象。</param>
    /// <returns>返回包含新增库存信息的 ServiceResponse 对象。</returns>
    /// <summary>
    /// 异步添加新的库存记录。
    /// </summary>
    /// <param name="stockRequest">包含 PaintProductId 和 StockQuantity 的请求对象。</param>
    /// <returns>返回新增库存实体。</returns>
    public async Task<PaintProductsStock> AddPaintProductsStock(PaintProductStockRequest stockRequest)
    {
        // DTO → Entity
        var newStock = _mapper.Map<PaintProductsStock>(stockRequest);
        newStock.CreatedAt = DateTime.Now; // 设置创建时间

        // 调用 Repository 添加
        await _paintStockRepository.AddPaintProductsStock(newStock);

        // 成功返回实体
        return newStock;
    }
}