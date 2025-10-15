using AutoMapper;
using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Extension;
using PaintSystemAPIVersionOne.Model;
using PaintSystemAPIVersionOne.Repositories;

namespace PaintSystemAPIVersionOne.Services;

public class PaintProductService 
{
    
    //DI 
    private readonly PaintProductRepository _paintProductRepository;
    private readonly IMapper _mapper;
    
    
    
    public PaintProductService(PaintProductRepository paintProductRepository ,IMapper mapper)
    {
        _paintProductRepository = paintProductRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    ///Return all products 
    /// </summary>
    /// <returns> List of PaintProduct </returns>
    public async Task<List<PaintProduct>>  GetAllPaintProduct()
    {
        var products = await _paintProductRepository.GetAllPaintProducts();

        if (products == null || products.Count == 0)
            // 抛异常，由中间件统一处理
            throw new KeyNotFoundException("No PaintProduct found");
        // 数据存在，业务返回成功
        return products; // 成功返回实体列表
        
    }
    
    
    
    public async Task<PaintProduct> GetProductById(int id)
    {
        var product = await _paintProductRepository.GetPaintProductById(id);

        if (product == null)
            // 找不到数据，抛异常，由中间件统一返回 404 + FormattedResponse
            throw new KeyNotFoundException("PaintProduct not found");
        return product; // 正常返回实体
    }
    
    
    
    
    
    /// <summary>
    ///  Get a PaintProductRequest(DTO) and initial a new paintProduct casting to repo layer
    /// </summary>
    /// <param name="paintProductRequest"></param>
    /// <returns> PaintProduct to controller</returns>
    public async Task<PaintProduct> AddProduct(PaintProductRequest paintProductRequest)
    {
        
            // DTO → Entity（AutoMapper）
            var paintProduct = _mapper.Map<PaintProduct>(paintProductRequest);

            // 调用 Repository 层添加
            await _paintProductRepository.AddProduct(paintProduct);
            
            // 抛异常，由中间件统一处理，返回 500 + FormattedResponse
            throw new InvalidOperationException("Add PaintProduct failed");
            
            return paintProduct;
            
    }
    
}