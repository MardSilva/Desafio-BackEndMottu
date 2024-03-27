using DesafioBackend.Mottu.Entities.MotorcyclesRental;
using System;
using Xunit;

namespace DesafioBackend.Mottu.MotorcyclesRental
{
    public class MotorcycleRentalUnitTests : MottuApplicationTestBase<MottuApplicationTestModule>
    {
        [Fact]
        public void Should_Calculate_TotalCost_Correctly()
        {
            var rental = new MotorcycleRental(
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                7, // 7 days of rental
                DateTime.Now
            );

            rental.CompleteRental(DateTime.Now.AddDays(7)); // assuming the rental was completed 7 days after it started

            Assert.Equal(210, rental.TotalCost); // considering the daily cost is 30
        }
    }
}