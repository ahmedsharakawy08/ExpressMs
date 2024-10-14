using ExpressMs.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ExpressMs.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ExpressMsController : AbpControllerBase
{
    protected ExpressMsController()
    {
        LocalizationResource = typeof(ExpressMsResource);
    }
}
