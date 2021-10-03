using Xedge.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.BaseService
{
    [Authorize(Roles = Constants.DriverRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthorizedDriverAPIController : APIController
    {
    }
}
