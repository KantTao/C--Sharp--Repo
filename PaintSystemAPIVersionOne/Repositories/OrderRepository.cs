using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PaintSystemAPIVersionOne.Data;
using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Repositories;

public class OrderRepository
{
    private readonly PaintDbContext _dbContext;
    private readonly ILogger<OrderRepository> _logger;
    
    public OrderRepository(PaintDbContext dbContext,ILogger<OrderRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
        
    }

    /// <summary>
    /// Get all users from Database using dbContext
    /// </summary>
    /// <returns> List of users </returns>
    public async Task<List<Order>> GetAllOrders()
    {
        try
        {
            var orders = await _dbContext.OrderTable.ToListAsync();
            return orders;
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching order", ex); // 这里可以考虑记录日志
        }
    }


    /// <summary>
    /// return a specific Order by id
    /// </summary>
    /// <param name="Id"></param>
    /// The <see cref="Order"/> object if found; otherwise, <c>null</c>.
    /// <returns>Order</returns>
    public async Task<Order?> GetOrderById(int id)
    {
        var order = await _dbContext.OrderTable.FirstOrDefaultAsync(o => o.Id == id);
        return order;
    }

    
    /// <summary>
    /// Adds a new order to the database.
    /// </summary>
    /// <param name="order">The <see cref="Order"/> entity to add.</param>
    /// <returns>Returns the newly added <see cref="Order"/> entity.</returns>
    /// <exception cref="InvalidOperationException">Thrown if adding the order fails.</exception>
    public async Task<Order> AddOrder(Order order)
    {
        try
        {
            await _dbContext.OrderTable.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            // 记录日志
            Console.WriteLine("==== Before logger ====");
            _logger.LogError(e, "Failed to add order to DataBase Logger Logger");
            Console.WriteLine("==== After logger ====");
            // 抛出带自定义消息的异常，并保留原始异常
            throw new InvalidOperationException("Add Order failed in Repo layer", e);
        }
    
        return order;
    }
    
    /// <summary>
    /// Deletes an order from the database by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the order to delete.</param>
    /// <returns>
    /// Returns the deleted <see cref="Order"/> if it exists; 
    /// otherwise, returns null.
    /// </returns>
    public async Task<Order?> DeleteById(int id)
    {
        // 1. 先查找订单
        var order = await _dbContext.OrderTable.FindAsync(id);
        if (order == null)
        {
            return null; // 没找到就返回 null
        }
        // 2. 删除订单
        _dbContext.OrderTable.Remove(order);
        await _dbContext.SaveChangesAsync();

        // 3. 返回被删除的订单
        return order;
    }
}