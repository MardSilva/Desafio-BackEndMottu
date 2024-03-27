using DesafioBackend.Mottu.Entities.DeliveryPersons;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace DesafioBackend.Mottu.DeliveryPersonTests
{

    public class DeliveryPersonIntegrationTests : MottuApplicationTestBase<MottuApplicationTestModule>
    {
        private readonly IRepository<DeliveryPerson, Guid> _deliveryPersonRepository;

        public DeliveryPersonIntegrationTests()
        {
            _deliveryPersonRepository = GetRequiredService<IRepository<DeliveryPerson, Guid>>();
        }

        [Fact]
        public async Task Should_Create_And_Retrieve_DeliveryPerson()
        {
            // Arrange
            var deliveryPerson = new DeliveryPerson(Guid.NewGuid(), "Valid Name", "12345678901234", new DateTime(1980, 1, 1), "CNH12345678", "A");
            await _deliveryPersonRepository.InsertAsync(deliveryPerson);

            // Act
            var retrieved = await _deliveryPersonRepository.GetAsync(deliveryPerson.Id);
            Assert.NotNull(retrieved);

            // Assert
            Assert.Equal("Valid Name", retrieved.Name);
        }
    }

}