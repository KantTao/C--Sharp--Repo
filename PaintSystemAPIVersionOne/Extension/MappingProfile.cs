using AutoMapper;
using PaintSystemAPIVersionOne.DTO;
using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Extension;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OrderCreateRequest, Order>();
        CreateMap<PaintProductRequest, PaintProduct>();
        CreateMap<PaintProductStockRequest, PaintProductsStock>();
        CreateMap<UserCreatRequest, User>();
    }
}

