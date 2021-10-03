using Xedge.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.BaseService
{
    [Authorize(Roles = Constants.UserRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthorizedAPIController : APIController
    {
    }
}
