using DesafioBackend.Mottu.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DesafioBackend.Mottu.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MottuEntityFrameworkCoreModule),
    typeof(MottuApplicationContractsModule)
    )]
public class MottuDbMigratorModule : AbpModule
{
}
