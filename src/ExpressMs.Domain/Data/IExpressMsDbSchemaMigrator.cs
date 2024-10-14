using System.Threading.Tasks;

namespace ExpressMs.Data;

public interface IExpressMsDbSchemaMigrator
{
    Task MigrateAsync();
}
