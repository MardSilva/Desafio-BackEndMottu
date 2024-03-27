using DesafioBackend.Mottu.DTO.MotorcylesRental;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DesafioBackend.Mottu.Interface
{
    public interface IMotorcycleRentalAppService : ICrudAppService<MotorcycleRentalDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMotorcycleRentalDto, MotorcycleRentalDto>
    {
        Task<MotorcycleRentalDto> CompleteRentalAsync(Guid id, DateTime returnDate);
    }
}