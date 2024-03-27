using DesafioBackend.Mottu.Samples;
using Xunit;

namespace DesafioBackend.Mottu.EntityFrameworkCore.Domains;

[Collection(MottuTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<MottuEntityFrameworkCoreTestModule>
{

}
