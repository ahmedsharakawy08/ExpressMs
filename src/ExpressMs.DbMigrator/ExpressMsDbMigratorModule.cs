using ExpressMs.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ExpressMs.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ExpressMsEntityFrameworkCoreModule),
    typeof(ExpressMsApplicationContractsModule)
    )]
public class ExpressMsDbMigratorModule : AbpModule
{
}
