using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBackend.Mottu.DTO.Motorcycles
{
    public class CreateUpdateMotorcycleDto
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
    }
}