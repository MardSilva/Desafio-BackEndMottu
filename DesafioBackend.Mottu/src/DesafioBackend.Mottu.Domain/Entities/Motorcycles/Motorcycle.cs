using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DesafioBackend.Mottu.Entities.Motorcycles
{
    public class Motorcycle : AuditedAggregateRoot<Guid>
    {
        public int Year { get; private set; }
        public string Model { get; private set; }
        public string LicensePlate { get; private set; }


        protected Motorcycle()
        {
        }

        public Motorcycle(Guid id, int year, string model, string licensePlate) : base(id)
        {
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
        }

        public void UpdateLicensePlate(string newLicensePlate)
        {
            LicensePlate = newLicensePlate;
        }
    }
}