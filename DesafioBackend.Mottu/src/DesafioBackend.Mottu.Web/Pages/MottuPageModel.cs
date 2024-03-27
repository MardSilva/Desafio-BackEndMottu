using DesafioBackend.Mottu.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DesafioBackend.Mottu.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MottuPageModel : AbpPageModel
{
    protected MottuPageModel()
    {
        LocalizationResourceType = typeof(MottuResource);
    }
}
