using Volo.Abp.Modularity;

namespace ExpressMs;

/* Inherit from this class for your domain layer tests. */
public abstract class ExpressMsDomainTestBase<TStartupModule> : ExpressMsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
