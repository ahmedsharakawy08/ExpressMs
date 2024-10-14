using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExpressMs.Data;
using Volo.Abp.DependencyInjection;

namespace ExpressMs.EntityFrameworkCore;

public class EntityFrameworkCoreExpressMsDbSchemaMigrator
    : IExpressMsDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreExpressMsDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ExpressMsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ExpressMsDbContext>()
            .Database
            .MigrateAsync();
    }
}
