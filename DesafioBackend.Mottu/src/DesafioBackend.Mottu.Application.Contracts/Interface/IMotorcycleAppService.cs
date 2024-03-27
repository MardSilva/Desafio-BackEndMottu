using DesafioBackend.Mottu.DTO.Motorcycles;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DesafioBackend.Mottu.Interface
{
    public interface IMotorcycleAppService : ICrudAppService<MotorcycleDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMotorcycleDto>
    {
        Task<MotorcycleDto> GetByLicensePlateAsync(string licensePlate);
    }
}