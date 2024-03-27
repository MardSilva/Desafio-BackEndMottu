using AutoMapper;
using DesafioBackend.Mottu.DTO.Orders;

public class OrderApplicationAutoMapperProfile : Profile
{
    public OrderApplicationAutoMapperProfile()
    {
        // mapping of Order entity to OrderDto
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();

        // to create an order, the Id is ignored because it will be generated automatically
        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}