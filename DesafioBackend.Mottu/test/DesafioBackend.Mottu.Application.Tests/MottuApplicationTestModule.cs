using Volo.Abp.Modularity;

namespace DesafioBackend.Mottu;

[DependsOn(
    typeof(MottuApplicationModule),
    typeof(MottuDomainTestModule)
)]
public class MottuApplicationTestModule : AbpModule
{

}
