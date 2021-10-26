using Xedge.Business.Services.Settings.Interfaces;
using Xedge.Infrastructure.Helpers;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Settings.Implementation
{
    public class SettingsService : ISettingsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<bool> CheckVisaAvailableAsync()
        {
            string value = await _unitOfWork.SettingsRepository.GetSettingValueUsingKeyAsync(Constants.VisaAvailable);
            return Convert.ToBoolean(value);
        }

        public async Task<double> GetDeliveryAsync()
        {
            string value = await _unitOfWork.SettingsRepository.GetSettingValueUsingKeyAsync(Constants.DeliveryKey);
            return Convert.ToDouble(value);
        }
    }
}
