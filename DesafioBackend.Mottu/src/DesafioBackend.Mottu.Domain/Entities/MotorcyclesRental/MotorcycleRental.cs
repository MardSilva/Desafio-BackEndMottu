using DesafioBackend.Mottu.Enums;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace DesafioBackend.Mottu.Entities.MotorcyclesRental
{
    public class MotorcycleRental : AuditedAggregateRoot<Guid>
    {
        public Guid DeliveryPersonId { get; private set; }
        public Guid MotorcycleId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateTime ExpectedEndDate { get; private set; }
        public int PlanDays { get; private set; }
        public decimal DailyRate { get; private set; }
        public decimal? TotalCost { get; private set; }
        public MotorcycleRentalStatus Status { get; private set; }

        protected MotorcycleRental() { }

        public MotorcycleRental(Guid id, Guid deliveryPersonId, Guid motorcycleId, int planDays, DateTime creationTime) : base(id)
        {
            DeliveryPersonId = deliveryPersonId;
            MotorcycleId = motorcycleId;
            StartDate = creationTime.AddDays(1);
            ExpectedEndDate = StartDate.AddDays(planDays);
            PlanDays = planDays;

            DailyRate = planDays switch
            {
                7 => 30m,
                15 => 28m,
                30 => 22m,
                _ => throw new ArgumentException("Invalid rental plan."),
            };

            Status = MotorcycleRentalStatus.Active;
        }

        public void CompleteRental(DateTime returnDate)
        {
            if (Status != MotorcycleRentalStatus.Active)
            {
                throw new BusinessException("The rental has already been completed or cancelled.");
            }

            EndDate = returnDate;
            var plannedDays = (ExpectedEndDate - StartDate).Days;
            var actualDays = (EndDate.Value - StartDate).Days;
            var extraDays = actualDays - plannedDays;

            // Calcula o custo base
            decimal baseCost = plannedDays * DailyRate;

            if (extraDays > 0)
            {
                // Custo adicional por dias extras
                TotalCost = baseCost + (extraDays * 50m);
            }
            else if (extraDays < 0)
            {
                // Aplica multa por entrega antecipada
                int unutilizedDays = Math.Abs(extraDays);
                decimal penaltyAmount = unutilizedDays * DailyRate * GetPenaltyRate();
                TotalCost = baseCost - penaltyAmount;
            }
            else
            {
                // Não há dias extras
                TotalCost = baseCost;
            }

            Status = MotorcycleRentalStatus.Completed;
        }

        private decimal GetPenaltyRate()
        {
            return PlanDays switch
            {
                7 => 0.20m,
                15 => 0.40m,
                30 => 0.60m,
                _ => throw new BusinessException("Invalid lease plan.")
            };
        }
    }
}