using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Business.Services.Sliders.Interfaces;
using Xedge.Infrastructure.DTOs.Sliders;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Business.Services.Sliders.Interfaces
{
    public interface ISlidersService
    {
        /// <summary>
        /// Get Sliders Order Desc (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingparameters"></param>
        /// <returns></returns>
        Task<PagedResult<SliderDTO>> GetSlidersAsync(PagingParameters pagingparameters);
    }
}
