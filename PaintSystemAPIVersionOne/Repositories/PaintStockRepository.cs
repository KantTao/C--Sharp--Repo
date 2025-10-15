using Microsoft.EntityFrameworkCore;
using PaintSystemAPIVersionOne.Data;
using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Repositories;

public class PaintStockRepository
{
    private readonly PaintDbContext _dbContext;

    public PaintStockRepository(PaintDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    /// <summary>
    /// Retrieves all paint product stock entries from the database.
    /// </summary>
    /// <returns>A list of <see cref="PaintProductsStock"/>.</returns>
    public async Task<List<PaintProductsStock>> GetAllPaintProductsStock()
    {
        return await _dbContext.PaintProductsStockTable.ToListAsync();
    }
    
    
    
    /// <summary>
    /// 异步根据指定的产品库存 ID 获取对应的 PaintProductsStock 实体。
    /// </summary>
    /// <param name="id">要查询的 PaintProductsStock 的唯一标识 ID。</param>
    /// <returns>
    /// 返回对应的 <see cref="PaintProductsStock"/> 对象；  
    /// 如果未找到对应记录，则返回 <c>null</c>。
    /// </returns>
    public async Task<PaintProductsStock?> GetPaintProductsStockById(int id)
    {
        var paintProductsStock = await _dbContext.PaintProductsStockTable.FirstOrDefaultAsync(p => p.Id == id);
        return paintProductsStock;
    }
    
    
    
    public async Task<PaintProductsStock> AddPaintProductsStock(PaintProductsStock stock)
    {
        try
        {
            await _dbContext.PaintProductsStockTable.AddAsync(stock);
            await _dbContext.SaveChangesAsync();
            return stock;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Add PaintProductsStock failed", ex);
        }

    }




}