using AutoMapper;
using DesafioBackend.Mottu.DTO.MotorcylesRental;
using DesafioBackend.Mottu.Entities.MotorcyclesRental;

namespace DesafioBackend.Mottu.Mapping
{
    public class MotorcycleRentalApplicationAutoMapperProfile : Profile
    {
        public MotorcycleRentalApplicationAutoMapperProfile()
        {
            CreateMap<MotorcycleRental, MotorcycleRentalDto>().ReverseMap();
            CreateMap<CreateUpdateMotorcycleRentalDto, MotorcycleRental>().ReverseMap();
        }
    }
}