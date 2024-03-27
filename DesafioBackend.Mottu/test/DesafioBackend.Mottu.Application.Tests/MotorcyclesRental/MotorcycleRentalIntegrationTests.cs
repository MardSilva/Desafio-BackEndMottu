using DesafioBackend.Mottu;
using DesafioBackend.Mottu.DTO.MotorcylesRental;
using DesafioBackend.Mottu.Enums;
using DesafioBackend.Mottu.Interface;
using System;
using System.Threading.Tasks;
using Xunit;

public class MotorcycleRentalIntegrationTests : MottuApplicationTestBase<MottuApplicationTestModule>
{
    private readonly IMotorcycleRentalAppService _motorcycleRentalAppService;

    public MotorcycleRentalIntegrationTests()
    {
        _motorcycleRentalAppService = GetRequiredService<IMotorcycleRentalAppService>();
    }

    [Fact]
    public async Task Should_Complete_Rental_Successfully()
    {
        // Arrange
        var createRentalDto = new CreateUpdateMotorcycleRentalDto
        {
            DeliveryPersonId = Guid.NewGuid(),
            MotorcycleId = Guid.NewGuid(),
            PlanDays = 7
        };

        // Act
        var rentalDto = await _motorcycleRentalAppService.CreateAsync(createRentalDto);
        var completedRentalDto = await _motorcycleRentalAppService.CompleteRentalAsync(rentalDto.Id, rentalDto.ExpectedEndDate);

        // Assert
        Assert.NotNull(completedRentalDto);
        Assert.Equal(MotorcycleRentalStatus.Completed, completedRentalDto.Status);
    }
}