using System;
using Volo.Abp.Application.Dtos;

namespace DesafioBackend.Mottu.DTO.Orders
{
    public class OrderDto : AuditedEntityDto<Guid>
    {
        public DateTime CreationTime { get; set; }
        public decimal Value { get; set; }
        public OrderStatus Status { get; set; }
    }
}