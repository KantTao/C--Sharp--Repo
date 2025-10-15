using AutoMapper;
using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Enum;
using PaintSystemAPIVersionOne.Extension;
using PaintSystemAPIVersionOne.Model;
using PaintSystemAPIVersionOne.Repositories;

namespace PaintSystemAPIVersionOne.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly IMapper _mapper;
    
    public OrderService(OrderRepository orderRepository,IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    
    
    /// <summary>
    ///ger all orders from _userRepository
    /// </summary>
    /// <returns>list of orders </returns>
    public async Task<ServiceResponse<List<Order>>> GetAllOrders()
    {
        var orders = await _orderRepository.GetAllOrders();

        if (orders == null || orders.Count == 0)
        {
            // 数据为空，业务返回失败
            return new ServiceResponse<List<Order>>(false, "No Order found", null);
        }

        // 数据存在，业务返回成功
        return new ServiceResponse<List<Order>>(true, "Users retrieved successfully", orders);
    }
    
    
    /// <summary>
    /// Retrieves an order by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier (ID) of the order to retrieve.</param>
    /// <returns>
    /// A <see cref="ServiceResponse{Order}"/> containing the order data if found; 
    /// otherwise, a response indicating that no order was found.
    /// </returns>
    public async Task<ServiceResponse<Order>> GetOrderById(int Id)
    {
        var order = await _orderRepository.GetOrderById(Id);

        if (order == null)
            return new ServiceResponse<Order>(false, "No order found", null);

        return new ServiceResponse<Order>(true, "Order retrieved successfully", order);
    }
    
    
    
    public async Task<ServiceResponse<Order>> AddOrder(OrderCreateRequest request)
    {
        try
        {
            // var order = new Order
            // {
            //     UserId = request.Id,
            //     TotalPrice = request.TotalPrice,
            //     OrderReference = request.OrderReference,
            //     OrderStatus = (OrderStatus)request.OrderStatus // 关键：int → enum
            // };
            
            //DTO transfer to Object with Auto Mapper 
            var order = _mapper.Map<Order>(request);
            
            // 调用 Repository 层
            var addedOrder = await _orderRepository.AddOrder(order);

            return new ServiceResponse<Order>(true, "Order retrieved successfully", order);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Order>(false, "Order Add Fail", null);
        }
    }
    
    
    
    public async Task<ServiceResponse<Order>> DeleteOrderById(int id)
    {
        try
        {
            // 调用 Repository 层删除
            var deletedOrder = await _orderRepository.DeleteById(id);

            if (deletedOrder == null)
            {
                return new ServiceResponse<Order>(false, "Order not found", null);
            }

            return new ServiceResponse<Order>(true, "Order deleted successfully", deletedOrder);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Order>(false, $"Failed to delete order: {ex.Message}", null);
        }
    }

}