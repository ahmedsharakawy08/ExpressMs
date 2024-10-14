using Microsoft.Extensions.Localization;
using ExpressMs.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ExpressMs.Blazor.WebApp.Tiered.Client;

[Dependency(ReplaceServices = true)]
public class ExpressMsBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ExpressMsResource> _localizer;

    public ExpressMsBrandingProvider(IStringLocalizer<ExpressMsResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
