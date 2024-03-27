using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DesafioBackend.Mottu.Data;
using Volo.Abp.DependencyInjection;

namespace DesafioBackend.Mottu.EntityFrameworkCore;

public class EntityFrameworkCoreMottuDbSchemaMigrator
    : IMottuDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMottuDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the MottuDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MottuDbContext>()
            .Database
            .MigrateAsync();
    }
}
