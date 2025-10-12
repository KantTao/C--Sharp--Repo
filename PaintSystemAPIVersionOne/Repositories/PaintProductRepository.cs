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

    
    public async Task<List<PaintProduct>> GetAllPaintProducts()
    {
        return await _dbContext.PaintProductTable.ToListAsync();
    }
    

}