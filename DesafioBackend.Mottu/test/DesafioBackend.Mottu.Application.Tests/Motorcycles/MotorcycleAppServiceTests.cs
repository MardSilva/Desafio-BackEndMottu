using DesafioBackend.Mottu.DTO.Motorcycles;
using DesafioBackend.Mottu.Entities.Motorcycles;
using DesafioBackend.Mottu.Interface;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace DesafioBackend.Mottu.Motorcycles
{
    public class MotorcycleAppServiceTests : MottuApplicationTestBase<MottuApplicationTestModule>
    {
        private readonly IMotorcycleAppService _motorcycleAppService;
        private readonly IRepository<Motorcycle, Guid> _repository;

        public MotorcycleAppServiceTests()
        {
            _motorcycleAppService = GetRequiredService<IMotorcycleAppService>();
            _repository = GetRequiredService<IRepository<Motorcycle, Guid>>();
        }

        [Fact]
        public async Task Should_Not_Allow_Duplicate_LicensePlate()
        {
            var motorcycle = new CreateUpdateMotorcycleDto
            {
                Year = 2020,
                Model = "Test Model",
                LicensePlate = "ABC1234"
            };

            // first insert
            await _motorcycleAppService.CreateAsync(motorcycle);

            // second insert needs to throw BusinessException (license plate already exists)
            await Assert.ThrowsAsync<BusinessException>(async () =>
            {
                await _motorcycleAppService.CreateAsync(motorcycle);
            });
        }
    }
}