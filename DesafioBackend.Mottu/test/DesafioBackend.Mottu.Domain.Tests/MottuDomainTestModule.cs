using Volo.Abp.Modularity;

namespace DesafioBackend.Mottu;

[DependsOn(
    typeof(MottuDomainModule),
    typeof(MottuTestBaseModule)
)]
public class MottuDomainTestModule : AbpModule
{

}
