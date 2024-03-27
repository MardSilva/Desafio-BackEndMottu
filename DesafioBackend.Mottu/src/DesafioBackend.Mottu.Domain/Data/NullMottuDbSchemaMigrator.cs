using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DesafioBackend.Mottu.Data;

/* This is used if database provider does't define
 * IMottuDbSchemaMigrator implementation.
 */
public class NullMottuDbSchemaMigrator : IMottuDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
