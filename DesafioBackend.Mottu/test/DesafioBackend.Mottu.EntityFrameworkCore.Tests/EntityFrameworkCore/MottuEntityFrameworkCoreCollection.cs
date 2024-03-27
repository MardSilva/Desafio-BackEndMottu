using Xunit;

namespace DesafioBackend.Mottu.EntityFrameworkCore;

[CollectionDefinition(MottuTestConsts.CollectionDefinitionName)]
public class MottuEntityFrameworkCoreCollection : ICollectionFixture<MottuEntityFrameworkCoreFixture>
{

}
