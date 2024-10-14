using System;
using System.Collections.Generic;
using System.Text;
using ExpressMs.Localization;
using Volo.Abp.Application.Services;

namespace ExpressMs;

/* Inherit your application services from this class.
 */
public abstract class ExpressMsAppService : ApplicationService
{
    protected ExpressMsAppService()
    {
        LocalizationResource = typeof(ExpressMsResource);
    }
}
