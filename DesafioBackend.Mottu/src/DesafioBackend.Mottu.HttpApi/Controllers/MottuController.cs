using DesafioBackend.Mottu.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DesafioBackend.Mottu.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MottuController : AbpControllerBase
{
    protected MottuController()
    {
        LocalizationResource = typeof(MottuResource);
    }
}
