using Microsoft.EntityFrameworkCore;
using PaintSystemAPIVersionOne.Data;
using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Repositories;

public class PaintProductRepository
{
    private readonly PaintDbContext _dbContext;


    public PaintProductRepository(PaintDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    /// <summary>
    /// return all PaintProduct from database 
    /// </summary>
    /// <returns>List of PaintProduct </returns>
    public async Task<List<PaintProduct>> GetAllPaintProducts()
    {
        return await _dbContext.PaintProductTable.ToListAsync();
    }


    /// <summary>
    /// return a specific PaintProduct by id
    /// </summary>
    /// <param name="Id"></param>
    /// The <see cref="PaintProduct"/> object if found; otherwise, <c>null</c>.
    /// <returns>PaintProduct</returns>
    public async Task<PaintProduct?> GetPaintProductById(int Id)
    {
        var paint = await _dbContext.PaintProductTable.FirstOrDefaultAsync(p => p.Id == Id);
        return paint;
    }
    
    
    
    /// <summary>
    /// Add new paintProduct to database 
    /// </summary>
    /// <param name="paintProduct"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<PaintProduct> AddProduct(PaintProduct paintProduct)
    {
        
        try
        {
            await _dbContext.PaintProductTable.AddAsync(paintProduct);
            await _dbContext.SaveChangesAsync();
            return paintProduct;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Add product failed", ex);
        }
        
    }
}