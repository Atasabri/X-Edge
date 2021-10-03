using Xedge.Infrastructure.DTOs.User;
using Xedge.Infrastructure.DTOs.User.Driver;
using Xedge.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.User.Interfaces
{
    public interface IDriverService
    {
        /// <summary>
        /// Edit Current Driver Profile Data Asynchronous
        /// </summary>
        /// <param name="editProfileDTO"></param>
        /// <returns></returns>
        Task<ActionState> EditProfileAsync(EditProfileDTO editProfileDTO);
        /// <summary>
        /// Get Current Driver Profile Data Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<DriverProfileDTO> ProfileAsync();
        /// <summary>
        /// Change Driver Password Asynchronous
        /// </summary>
        /// <param name="changePasswordDTO"></param>
        /// <returns></returns>
        Task<ActionState> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
    }
}
