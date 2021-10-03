using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Infrastructure.DashboardViewModels.News;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Business.Services.News.Interfaces.Dashboard
{
    public interface IDashboardNewsService
    {
        /// <summary>
        /// Adding New News Asynchronous
        /// </summary>
        /// <param name="addNewsViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateNewsAsync(AddNewsViewModel addNewsViewModel);
        /// <summary>
        /// Edit News Asynchronous
        /// </summary>
        /// <param name="editNewsViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditNewsAsync(EditNewsViewModel editNewsViewModel);
        /// <summary>
        /// Delete News Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteNewsAsync(int id);
        /// <summary>
        /// Get Newss (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingNewsViewModel>> GetDashboardNewsAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get News Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<NewsViewModel> GetNewsDetailsAsync(int Id);
        /// <summary>
        /// Delete Image From News Asynchronous
        /// </summary>
        /// <param name="newsid"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<ActionState> DeleteNewsImageAsync(int newsid, string path);
    }
}
