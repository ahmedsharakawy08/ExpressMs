using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ExpressMs.Data;

/* This is used if database provider does't define
 * IExpressMsDbSchemaMigrator implementation.
 */
public class NullExpressMsDbSchemaMigrator : IExpressMsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
