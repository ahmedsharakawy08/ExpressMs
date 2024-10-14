using Volo.Abp.Modularity;

namespace ExpressMs;

[DependsOn(
    typeof(ExpressMsApplicationModule),
    typeof(ExpressMsDomainTestModule)
)]
public class ExpressMsApplicationTestModule : AbpModule
{

}
