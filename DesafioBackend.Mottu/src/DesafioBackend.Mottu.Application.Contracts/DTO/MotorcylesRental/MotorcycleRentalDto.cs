using DesafioBackend.Mottu.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DesafioBackend.Mottu.DTO.MotorcylesRental
{
    public class MotorcycleRentalDto : AuditedEntityDto<Guid>
    {
        public Guid DeliveryPersonId { get; set; }
        public Guid MotorcycleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public int PlanDays { get; set; }
        public decimal DailyRate { get; set; }
        public decimal? TotalCost { get; set; }
        public MotorcycleRentalStatus Status { get; set; }
    }
}