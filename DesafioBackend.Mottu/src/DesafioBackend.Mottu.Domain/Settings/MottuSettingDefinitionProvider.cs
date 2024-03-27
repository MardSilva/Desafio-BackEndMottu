using Volo.Abp.Settings;

namespace DesafioBackend.Mottu.Settings;

public class MottuSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MottuSettings.MySetting1));
    }
}
