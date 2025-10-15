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
    public async Task<ServiceResponse<List<PaintProduct>>> GetAllPaintProduct()
    {
        var products = await _paintProductRepository.GetAllPaintProducts();

        if (products == null || products.Count == 0)
        {
            // 数据为空，业务返回失败
            return new ServiceResponse<List<PaintProduct>>(false, "No PaintProduct found", null);
        }

        // 数据存在，业务返回成功
        return new ServiceResponse<List<PaintProduct>>(true, "PaintProduct retrieved successfully", products);
    }
    
    public async Task<ServiceResponse<PaintProduct>> GetProductById(int id)
    {
        var product = await _paintProductRepository.GetPaintProductById(id);

        if (product == null)
        {
            return new ServiceResponse<PaintProduct>(false, "PaintProduct No Found", null);
        }

        return new ServiceResponse<PaintProduct>(true, "PaintProduct Found", product);
    }
    
    
    
    /// <summary>
    ///  Get a PaintProductRequest(DTO) and initial a new paintProduct casting to repo layer
    /// </summary>
    /// <param name="paintProductRequest"></param>
    /// <returns> PaintProduct of ServiceResponse to controller</returns>
    public async Task<ServiceResponse<PaintProduct>> AddProduct(PaintProductRequest paintProductRequest)
    {
        var ids = new[]
        {
            paintProductRequest.paintBrandId,
            paintProductRequest.paintCategoryId,
            paintProductRequest.paintSeriesId
        };
        
        //DTO transfer to PaintProduct Object 
        
        
        // 如果有任意一个 <= 0，则返回错误   有了fluentValidation后 可以直接取消 
        // if (ids.Any(id => id <= 0))
        // {
        //     return new ServiceResponse<PaintProduct>
        //     {
        //         IsSuccess = false,
        //         Message = "Incorrect ID Input "
        //     };
        // }
        
        
        // var paintProduct = new PaintProduct
        // {
        //     Name = paintProductRequest.name,
        //     PricePerLitre = paintProductRequest.PricePerLitre,
        //     Color = paintProductRequest.color,
        //     GlossLevel = paintProductRequest.glossLevel,
        //     BaseType = paintProductRequest.baseType,
        //     Size = paintProductRequest.size,
        //     Stock = paintProductRequest.stock,
        //     PaintBrandId = paintProductRequest.paintBrandId,
        //     PaintSeriesId = paintProductRequest.paintSeriesId,
        //     PaintCategoryId = paintProductRequest.paintCategoryId
        // };
        //            var order = _mapper.Map<Order>(request);
        
        // DTO Transfer to Object  with AutoMapper
        var paintProduct = _mapper.Map<PaintProduct>(paintProductRequest);
        
        await _paintProductRepository.AddProduct(paintProduct);
        return  new ServiceResponse<PaintProduct>(true, "Created successfully", paintProduct);
    }
    
}