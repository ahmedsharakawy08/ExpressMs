using Volo.Abp.Modularity;

namespace ExpressMs;

public abstract class ExpressMsApplicationTestBase<TStartupModule> : ExpressMsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
