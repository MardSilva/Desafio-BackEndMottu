using Volo.Abp.Modularity;

namespace DesafioBackend.Mottu;

/* Inherit from this class for your domain layer tests. */
public abstract class MottuDomainTestBase<TStartupModule> : MottuTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
