using System;
using System.Collections.Generic;
using System.Text;
using DesafioBackend.Mottu.Localization;
using Volo.Abp.Application.Services;

namespace DesafioBackend.Mottu;

/* Inherit your application services from this class.
 */
public abstract class MottuAppService : ApplicationService
{
    protected MottuAppService()
    {
        LocalizationResource = typeof(MottuResource);
    }
}
