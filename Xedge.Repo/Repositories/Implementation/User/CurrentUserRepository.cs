using Xedge.Repo.Repositories.Interfaces.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xedge.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Xedge.Infrastructure.Helpers;

namespace Xedge.Repo.Repositories.Implementation.User
{
    public class CurrentUserRepository : ICurrentUserRepository
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<Domain.Models.User> _userManager;

        public CurrentUserRepository(IHttpContextAccessor accessor, UserManager<Domain.Models.User> userManager)
        {
            this._accessor = accessor;
            this._userManager = userManager;
        }
        public async Task<string> GetCurrentUserId()
        {
            return _accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public async Task<string> GetCurrentUserName()
        {
            return _accessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
        public async Task<Domain.Models.User> GetCurrentUser()
        {
            return await _userManager.FindByIdAsync(await this.GetCurrentUserId());
        }

        public bool CheckIfUserLogedin()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated 
                && _accessor.HttpContext.User.IsInRole(Constants.UserRoleName); 
        }
    }
}
