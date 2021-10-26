﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Settings.Interfaces
{
    public interface ISettingsService
    {
        /// <summary>
        /// Get Delivery From Settings Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<double> GetDeliveryAsync();
        /// <summary>
        /// Check Visa is Available Or Not Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<bool> CheckVisaAvailableAsync();
    }
}
