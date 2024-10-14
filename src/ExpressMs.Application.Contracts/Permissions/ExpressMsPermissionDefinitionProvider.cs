using ExpressMs.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ExpressMs.Permissions;

public class ExpressMsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ExpressMsPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ExpressMsPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ExpressMsResource>(name);
    }
}
