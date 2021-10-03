﻿using Xedge.Infrastructure.DashboardViewModels.Sliders;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Sliders.Interfaces.Dashboard
{
    public interface IDashboardSlidersService
    {
        /// <summary>
        /// Adding New Slider Asynchronous
        /// </summary>
        /// <param name="addSliderViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateSliderAsync(AddSliderViewModel addSliderViewModel);
        /// <summary>
        /// Edit Slider Asynchronous
        /// </summary>
        /// <param name="editSliderViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditSliderAsync(EditSliderViewModel editSliderViewModel);
        /// <summary>
        /// Delete Slider Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteSliderAsync(int id);
        /// <summary>
        /// Get Sliders (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<SliderViewModel>> GetDashboardSlidersAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Slider Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<SliderViewModel> GetSliderDetailsAsync(int Id);
    }
}
