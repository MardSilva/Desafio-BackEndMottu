using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Validation;

namespace DesafioBackend.Mottu.Entities.DeliveryPersons
{
    public class DeliveryPerson : AuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string CnhNumber { get; private set; }
        public string CnhType { get; private set; }
        public string CnhImageType { get; private set; }
        public ICollection<Order> Orders { get; private set; }



        protected DeliveryPerson()
        {
            Orders = new List<Order>();
        }

        public DeliveryPerson(Guid id, string name, string cnpj, DateTime birthDate, string cnhNumber, string cnhType) : base(id)
        {
            SetName(name);
            SetCnpj(cnpj);
            BirthDate = birthDate;
            SetCnhNumber(cnhNumber);
            SetCnhType(cnhType);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new AbpValidationException("Name cannot be empty.");
            Name = name;
        }

        public void SetCnpj(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) throw new AbpValidationException("CNPJ cannot be empty.");
            Cnpj = cnpj;
        }

        public void SetCnhNumber(string cnhNumber)
        {
            if (string.IsNullOrWhiteSpace(cnhNumber)) throw new AbpValidationException("CNH Number cannot be empty.");
            CnhNumber = cnhNumber;
        }

        public void SetCnhType(string cnhType)
        {
            if (string.IsNullOrWhiteSpace(cnhType)) throw new AbpValidationException("CNH Type cannot be empty.");
            if (!new[] { "A", "B", "AB" }.Contains(cnhType)) throw new AbpValidationException("Invalid CNH Type.");
            CnhType = cnhType;
        }

        public void UpdateCnhImageType(string cnhImageType)
        {
            if (string.IsNullOrWhiteSpace(cnhImageType)) throw new AbpValidationException("CNH Image Type cannot be empty.");
            CnhImageType = cnhImageType;
        }
    }
}