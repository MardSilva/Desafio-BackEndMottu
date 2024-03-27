using DesafioBackend.Mottu.DTO.DeliveryPersons;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DesafioBackend.Mottu.Interface
{
    public interface IDeliveryPersonAppService : ICrudAppService<DeliveryPersonDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDeliveryPersonDto, CreateUpdateDeliveryPersonDto>
    {
        Task<DeliveryPersonDto> UpdateCnhImageAsync(Guid id, byte[] cnhImage);
    }
}