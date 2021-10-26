﻿using Xedge.Business.Services.User.Interfaces;
using Xedge.Infrastructure.DTOs.User;
using Xedge.Repo.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using System.Linq;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Manage_Files;
using Microsoft.Extensions.Localization;
using Xedge.Resources;
using Xedge.Business.Helpers;

namespace Xedge.Business.Services.User.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly AuthenticationHandler _authenticationHandler;

        public UserService(IUnitOfWork unitOfWork,
            UserManager<Domain.Models.User> userManager, 
            IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer, AuthenticationHandler authenticationHandler)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
            this._mapper = mapper;
            this._stringLocalizer = stringLocalizer;
            this._authenticationHandler = authenticationHandler;
        }
        public async Task<ActionState> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            var actionState = new ActionState();
            // Get User Using Phone
            var user = _userManager.Users.FirstOrDefault(user => user.PhoneNumber == resetPasswordDTO.Phone);
            if(user == null)
            {
                actionState.ErrorMessages.Add(_stringLocalizer["No User With Phone '{0}'", resetPasswordDTO.Phone]);
                return actionState;
            }
            // Reset User Current Password With New Password
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDTO.ResetPasswordToken, resetPasswordDTO.NewPassword);
            
            if(result.Succeeded)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.AddRange(result.Errors.Select(error => error.Description).ToList());
            return actionState;
        }

        public async Task<ActionState> EditProfileAsync(EditProfileDTO editProfileDTO)
        {
            var actionState = new ActionState();
            // Get Current Logined User
            var user = await _unitOfWork.CurrentUserRepository.GetCurrentUser();
            // Change User Data
            user.FullName = editProfileDTO.FullName;
            user.UserName = editProfileDTO.Email;
            user.Email = editProfileDTO.Email;
            user.PhoneNumber = editProfileDTO.Phone;
            var checkPhoneResult = await _authenticationHandler.CheckPhoneNumberAvailableAsync(user.PhoneNumber, user.Id);
            if (!checkPhoneResult.ExcuteSuccessfully)
            {
                actionState.ErrorMessages.AddRange(checkPhoneResult.ErrorMessages);
                return actionState;
            }
            // Update User
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                // Change Image 
                if (editProfileDTO.Photo != null)
                {
                    var savingImageData = new SavingFileData() { fileName = user.Id, folderName = "Users", File = editProfileDTO.Photo };
                    await _unitOfWork.SystemFilesRepository.SaveFileAsync(savingImageData);
                }
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.AddRange(result.Errors.Select(error => error.Description).ToList());
            return actionState;
        }

        public async Task<ProfileDTO> ProfileAsync()
        {
            // Get Current Logined User
            var user = await _unitOfWork.CurrentUserRepository.GetCurrentUser();

            // User Mapping
            var profile = _mapper.Map<Domain.Models.User, ProfileDTO>(user);
            // Get External Login Data
            var logins = await _userManager.GetLoginsAsync(user);
            if(logins.Any())
            {
                profile.Provider = logins[0].LoginProvider;
                profile.ExternalLoginId = logins[0].ProviderKey;
            }
            // Get Image If Exist
            var file = new FileBaseData() { fileName = user.Id, folderName = "Users" };
            bool exist = _unitOfWork.SystemFilesRepository.CheckFileExist(file);
            if(exist)
            {
                profile.Photo = "/Uploads/Users/" + user.Id + ".jpg";
            }
            return profile;
        }

        public async Task<ActionState> ChangeLoginedUserCurrentLanguageAsync(Languages language)
        {
            var actionState = new ActionState();
            var user = await _unitOfWork.CurrentUserRepository.GetCurrentUser();
            user.CurrentLangauge = language;
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.AddRange(result.Errors.Select(error => error.Description).ToList());
            return actionState;
        }

        public async Task<ActionState> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
        {
            var actionState = new ActionState();
            // Get Current Logined User
            var user = await _unitOfWork.CurrentUserRepository.GetCurrentUser();
            // Change Password Of Current User
            var result = await _userManager.ChangePasswordAsync(user, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);
            if (result.Succeeded)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.AddRange(result.Errors.Select(error => error.Description).ToList());
            return actionState;
        }
    }
}
