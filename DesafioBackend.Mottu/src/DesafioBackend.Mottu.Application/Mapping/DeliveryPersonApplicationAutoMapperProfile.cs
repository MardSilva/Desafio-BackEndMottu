using AutoMapper;
using DesafioBackend.Mottu.DTO.DeliveryPersons;
using DesafioBackend.Mottu.Entities.DeliveryPersons;

namespace DesafioBackend.Mottu.Mapping
{
    public class DeliveryPersonApplicationAutoMapperProfile : Profile
    {
        public DeliveryPersonApplicationAutoMapperProfile()
        {
            CreateMap<DeliveryPerson, DeliveryPersonDto>().ReverseMap();
            CreateMap<CreateUpdateDeliveryPersonDto, DeliveryPerson>().ReverseMap();
        }
    }
}