using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Repo.Repositories.Interfaces.User
{
    public interface ICurrentUserRepository
    {
        /// <summary>
        /// Get Cuurent User Id 
        /// </summary>
        /// <returns></returns>
        Task<string> GetCurrentUserId();
        /// <summary>
        /// Get Cuurent User Name
        /// </summary>
        /// <returns></returns>
        Task<string> GetCurrentUserName();
        /// <summary>
        /// Get Current User As Identity User
        /// </summary>
        /// <returns></returns>
        Task<Domain.Models.User> GetCurrentUser();
        /// <summary>
        /// Check If User Loged in 
        /// </summary>
        /// <returns></returns>
        bool CheckIfUserLogedin();
    }
}
