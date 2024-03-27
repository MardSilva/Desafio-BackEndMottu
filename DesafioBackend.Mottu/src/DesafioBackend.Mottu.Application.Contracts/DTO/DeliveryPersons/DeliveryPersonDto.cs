using System;
using Volo.Abp.Application.Dtos;

namespace DesafioBackend.Mottu.DTO.DeliveryPersons
{
    public class DeliveryPersonDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime BirthDate { get; set; }
        public string CnhNumber { get; set; }
        public string CnhType { get; set; }
        public string CnhImageType { get; set; }
    }
}