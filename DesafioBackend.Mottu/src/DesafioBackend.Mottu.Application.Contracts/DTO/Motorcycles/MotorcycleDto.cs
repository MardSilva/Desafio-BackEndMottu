using System;
using Volo.Abp.Application.Dtos;

namespace DesafioBackend.Mottu.DTO.Motorcycles
{
    public class MotorcycleDto : AuditedEntityDto<Guid>
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
    }
}