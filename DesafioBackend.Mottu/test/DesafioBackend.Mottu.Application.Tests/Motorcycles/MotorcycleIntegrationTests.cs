using DesafioBackend.Mottu.DTO.Motorcycles;
using DesafioBackend.Mottu.Entities.Motorcycles;
using DesafioBackend.Mottu.Interface;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace DesafioBackend.Mottu.Motorcycles
{
    public class MotorcycleIntegrationTests : MottuApplicationTestBase<MottuApplicationTestModule>
    {
        private readonly IMotorcycleAppService _motorcycleAppService;
        private readonly IRepository<Motorcycle, Guid> _motorcycleRepository;

        public MotorcycleIntegrationTests()
        {
            _motorcycleAppService = GetRequiredService<IMotorcycleAppService>();
            _motorcycleRepository = GetRequiredService<IRepository<Motorcycle, Guid>>();
        }

        [Fact]
        public async Task Should_Create_And_Retrieve_Motorcycle_Successfully()
        {
            var input = new CreateUpdateMotorcycleDto
            {
                Year = 2021,
                Model = "Integration Test Model",
                LicensePlate = "DEF5678"
            };

            var result = await _motorcycleAppService.CreateAsync(input);

            // assert that the returned motorcycle has an Id
            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.Id);

            // assert that the motorcycle was created and can be retrieved
            var retrieved = await _motorcycleRepository.FindAsync(result.Id);
            Assert.NotNull(retrieved);

            // assert that the retrieved motorcycle matches the input
            Assert.Equal(input.Model, retrieved.Model);
            Assert.Equal(input.LicensePlate, retrieved.LicensePlate);
        }
    }
}