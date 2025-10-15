using AutoMapper;
using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Enum;
using PaintSystemAPIVersionOne.Exceptions;
using PaintSystemAPIVersionOne.Extension;
using PaintSystemAPIVersionOne.Model;
using PaintSystemAPIVersionOne.Repositories;

namespace PaintSystemAPIVersionOne.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(OrderRepository orderRepository, IMapper mapper)
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

    // FormattedResponse<T>
    public async Task<Order> GetOrderById(int Id)
    {
        var order = await _orderRepository.GetOrderById(Id);
        
        if (order == null)
            //MidWare will catch this exception and formated result to customer-end 
            throw new KeyNotFoundException("No order found"); // 抛异常，由中间件统一返回 404
        
        return order; // 正常返回实体
    }


    public async Task<Order> AddOrder(OrderCreateRequest request)
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
            // 调用 Repository 层新增订单 ：不需要 try/catch，错误直接抛出，中间件统一处理。
            var addedOrder = await _orderRepository.AddOrder(order);
            return addedOrder;

    }

    public async Task<Order>  DeleteOrderById(int id)
    {
            // 调用 Repository 层删除
            var deletedOrder = await _orderRepository.DeleteById(id);
            // 如果未找到订单，直接抛异常，由中间件统一返回 404
            if (deletedOrder == null)
                throw new KeyNotFoundException("Order not found");
            // 成功返回被删除的订单
            return deletedOrder;
    }
}