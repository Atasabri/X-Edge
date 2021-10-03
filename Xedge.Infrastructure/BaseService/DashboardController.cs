using Xedge.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Xedge.Infrastructure.Error_Handling;

namespace Xedge.Infrastructure.BaseService
{
    //[DashboardErrorHandlingFilter]
    [Authorize(Roles = Admin.AdminRoleName + "," + Admin.EditorRoleName)]
    public class DashboardController : Controller
    {
    }
}
