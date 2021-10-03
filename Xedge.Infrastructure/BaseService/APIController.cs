using Xedge.Infrastructure.Error_Handling;
using Xedge.Resources;
using Xedge.Resources.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace Xedge.Infrastructure.BaseService
{
    [APIErrorHandlingFilter]
    [Route("{culture}/api/[controller]")]
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    [ApiController]
    public class APIController : ControllerBase
    {

    }
}
