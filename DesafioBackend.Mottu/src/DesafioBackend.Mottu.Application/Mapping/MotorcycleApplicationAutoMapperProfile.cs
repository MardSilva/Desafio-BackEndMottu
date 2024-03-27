using AutoMapper;
using DesafioBackend.Mottu.DTO.Motorcycles;
using DesafioBackend.Mottu.Entities.Motorcycles;

namespace DesafioBackend.Mottu.Mapping
{
    public class MotorcycleApplicationAutoMapperProfile : Profile
    {
        public MotorcycleApplicationAutoMapperProfile()
        {
            CreateMap<Motorcycle, MotorcycleDto>().ReverseMap();
            CreateMap<CreateUpdateMotorcycleDto, Motorcycle>().ReverseMap();
        }
    }
}