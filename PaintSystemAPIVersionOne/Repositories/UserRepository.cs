using Microsoft.EntityFrameworkCore;
using PaintSystemAPIVersionOne.Data;
using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Repositories;

public class UserRepository
{
    
    
    private readonly PaintDbContext _dbContext;

    public UserRepository(PaintDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
   
    /// <summary>
    /// Get all users from Database using dbContext
    /// </summary>
    /// <returns> List of users </returns>
    public async  Task<List<User>>  GetAllUsers()
    {
        return await _dbContext.UserTable.ToListAsync();
    }
    
    //
    
    
}