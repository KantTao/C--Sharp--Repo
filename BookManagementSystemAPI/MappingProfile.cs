using AutoMapper;
using BookManagementSystemAPI.Models;

namespace BookManagementSystemAPI;

public class MappingProfile:Profile
{
    
    public MappingProfile()
    {   //用来定义对象之间如何自动映射（复制属性值）
        CreateMap<BookCreateRequest,Book>(); 
    }
    
}