﻿using AutoMapper;
using Xedge.Business.Helpers;
using Xedge.Business.Services.User.Interfaces;
using Xedge.Infrastructure.DTOs.User;
using Xedge.Infrastructure.DTOs.User.Driver;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Manage_Files;
using Xedge.Repo.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.User.Implementation
{
    public class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly IMapper _mapper;
        private readonly AuthenticationHandler _authenticationHandler;

        public DriverService(IUnitOfWork unitOfWork,
            UserManager<Domain.Models.User> userManager,
            IMapper mapper, AuthenticationHandler authenticationHandler)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
            this._mapper = mapper;
            this._authenticationHandler = authenticationHandler;
        }

        public async Task<ActionState> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
        {
            var actionState = new ActionState();
            // Get Current Logined Driver
            var driver = await _unitOfWork.UsersRepository.GetCurrentUser();
            // Change Password Of Current Driver
            var result = await _userManager.ChangePasswordAsync(driver, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);
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
            // Get Current Logined Driver
            var driver = await _unitOfWork.UsersRepository.GetCurrentUser();
            // Change Driver Data
            driver.FullName = editProfileDTO.FullName;
            driver.UserName = editProfileDTO.Email;
            driver.Email = editProfileDTO.Email;
            driver.PhoneNumber = editProfileDTO.Phone;
            var checkPhoneResult = await _authenticationHandler.CheckPhoneNumberAvailableAsync(driver.PhoneNumber, driver.Id);
            if (!checkPhoneResult.ExcuteSuccessfully)
            {
                actionState.ErrorMessages.AddRange(checkPhoneResult.ErrorMessages);
                return actionState;
            }
            // Update Driver
            var result = await _userManager.UpdateAsync(driver);
            if (result.Succeeded)
            {
                // Change Image 
                if (editProfileDTO.Photo != null)
                {
                    var savingImageData = new SavingFileData() { fileName = driver.Id, folderName = "Drivers", File = editProfileDTO.Photo };
                    await _unitOfWork.SystemFilesRepository.SaveFileAsync(savingImageData);
                }
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.AddRange(result.Errors.Select(error => error.Description).ToList());
            return actionState;
        }

        public async Task<DriverProfileDTO> ProfileAsync()
        {
            // Get Current Logined Driver
            var driver = await _unitOfWork.UsersRepository.GetCurrentUser();

            // Driver Mapping
            var profile = _mapper.Map<Domain.Models.User, DriverProfileDTO>(driver);
            // Get Image If Exist
            var file = new FileBaseData() { fileName = driver.Id, folderName = "Drivers" };
            bool exist = _unitOfWork.SystemFilesRepository.CheckFileExist(file);
            if (exist)
            {
                profile.Photo = "/Uploads/Drivers/" + driver.Id + ".jpg";
            }
            return profile;
        }
    }
}
