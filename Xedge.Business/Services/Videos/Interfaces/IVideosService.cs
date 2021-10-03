using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Infrastructure.DTOs.Videos;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Business.Services.Videos.Interfaces
{
    public interface IVideosService
    {
        /// <summary>
        /// Get All Videos (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingparameters"></param>
        /// <returns></returns>
        Task<PagedResult<VideoDTO>> GetVideosAsync(PagingParameters pagingparameters);
    }
}
