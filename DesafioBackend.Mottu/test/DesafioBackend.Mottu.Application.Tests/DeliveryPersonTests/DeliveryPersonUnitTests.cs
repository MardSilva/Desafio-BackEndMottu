using DesafioBackend.Mottu.Entities.DeliveryPersons;
using System;
using Volo.Abp;
using Xunit;

namespace DesafioBackend.Mottu.DeliveryPersonTests
{
    public class DeliveryPersonUnitTests : MottuApplicationTestBase<MottuApplicationTestModule>
    {
        [Fact]
        public void Should_Throw_Exception_For_Invalid_CNH()
        {
            var exception = Assert.Throws<BusinessException>(() =>
                new DeliveryPerson(Guid.NewGuid(), "Test Name", "12345678901", DateTime.Now, "InvalidCNH", "A"));

            Assert.Equal("CNH Number is invalid.", exception.Message);
        }
    }
}
