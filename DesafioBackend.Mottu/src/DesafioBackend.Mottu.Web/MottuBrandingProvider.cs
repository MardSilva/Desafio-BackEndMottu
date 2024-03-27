using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DesafioBackend.Mottu.Web;

[Dependency(ReplaceServices = true)]
public class MottuBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Mottu";
}
