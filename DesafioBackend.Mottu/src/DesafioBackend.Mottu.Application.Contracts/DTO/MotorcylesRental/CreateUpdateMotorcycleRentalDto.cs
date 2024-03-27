using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBackend.Mottu.DTO.MotorcylesRental
{
    public class CreateUpdateMotorcycleRentalDto
    {
        public Guid DeliveryPersonId { get; set; }
        public Guid MotorcycleId { get; set; }
        public int PlanDays { get; set; }
    }
}