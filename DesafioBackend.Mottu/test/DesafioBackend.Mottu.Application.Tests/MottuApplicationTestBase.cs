using Volo.Abp.Modularity;

namespace DesafioBackend.Mottu;

public abstract class MottuApplicationTestBase<TStartupModule> : MottuTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}