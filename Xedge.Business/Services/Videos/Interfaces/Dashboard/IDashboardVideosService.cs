using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Infrastructure.DashboardViewModels.Videos;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Business.Services.Videos.Interfaces.Dashboard
{
    public interface IDashboardVideosService
    {
        /// <summary>
        /// Adding New Video Asynchronous
        /// </summary>
        /// <param name="addVideoViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateVideoAsync(AddVideoViewModel addVideoViewModel);
        /// <summary>
        /// Edit Video Asynchronous
        /// </summary>
        /// <param name="editVideoViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditVideoAsync(EditVideoViewModel editVideoViewModel);
        /// <summary>
        /// Delete Video Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteVideoAsync(int id);
        /// <summary>
        /// Get Videos (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingVideoViewModel>> GetDashboardVideosAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Video Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<VideoViewModel> GetVideoDetailsAsync(int Id);
    }
}
