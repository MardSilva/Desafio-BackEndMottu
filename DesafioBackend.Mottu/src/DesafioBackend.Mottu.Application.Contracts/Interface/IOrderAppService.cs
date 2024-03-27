using DesafioBackend.Mottu.DTO.Orders;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DesafioBackend.Mottu.Interface
{
    public interface IOrderAppService : ICrudAppService<OrderDto, Guid, PagedAndSortedResultRequestDto, CreateOrderDto, OrderDto>
    {
        Task NotifyDeliveryPersonsAsync(Guid orderId, decimal value, DateTime creationTime);
        Task AcceptOrderAsync(Guid orderId, Guid deliveryPersonId);
        Task CompleteOrderAsync(Guid orderId);
    }
}