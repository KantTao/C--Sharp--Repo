using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Extension;
using PaintSystemAPIVersionOne.Model;
using PaintSystemAPIVersionOne.Repositories;

namespace PaintSystemAPIVersionOne.Services;

public class PaintProductService
{   
    //DI 
    private readonly PaintProductRepository _paintProductRepository;


    public PaintProductService(PaintProductRepository paintProductRepository)
    {
        _paintProductRepository = paintProductRepository;
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
    
    
    public async Task <ServiceResponse<PaintProduct>> GetProductById(int id)
    {
        var product = await _paintProductRepository.GetPaintProductById(id);
        
        if (product == null)
        {
            return new ServiceResponse<PaintProduct>(false, "PaintProduct No Found",null);
        }
        return new ServiceResponse<PaintProduct>(true, "PaintProduct Found", product);
    }

    
    
    public async Task<ServiceResponse<PaintProduct>> AddProduct(PaintProductRequest paintProductRequest)
    {
        //DTO transfer to PaintProduct Object 
        PaintProduct newPaintProduct= new PaintProduct(paintProductRequest.)
            
    }

    
    



}