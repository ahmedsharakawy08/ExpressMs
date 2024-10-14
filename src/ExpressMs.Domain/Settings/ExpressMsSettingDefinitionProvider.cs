using Volo.Abp.Settings;

namespace ExpressMs.Settings;

public class ExpressMsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ExpressMsSettings.MySetting1));
    }
}
