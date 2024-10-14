using Volo.Abp.Modularity;

namespace ExpressMs;

[DependsOn(
    typeof(ExpressMsDomainModule),
    typeof(ExpressMsTestBaseModule)
)]
public class ExpressMsDomainTestModule : AbpModule
{

}
