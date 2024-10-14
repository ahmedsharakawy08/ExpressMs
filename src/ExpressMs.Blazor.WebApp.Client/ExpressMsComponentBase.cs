using ExpressMs.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ExpressMs.Blazor.WebApp.Client;

public abstract class ExpressMsComponentBase : AbpComponentBase
{
    protected ExpressMsComponentBase()
    {
        LocalizationResource = typeof(ExpressMsResource);
    }
}
