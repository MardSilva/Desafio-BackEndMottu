using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBackend.Mottu.DTO.DeliveryPersons
{
    public class CreateUpdateDeliveryPersonDto
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime BirthDate { get; set; }
        public string CnhNumber { get; set; }
        public string CnhType { get; set; }
    }
}