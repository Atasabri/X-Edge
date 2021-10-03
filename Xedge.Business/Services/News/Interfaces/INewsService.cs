using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Infrastructure.DTOs.News;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Business.Services.News.Interfaces
{
    public interface INewsService
    {
        /// <summary>
        /// Get All News (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingparameters"></param>
        /// <returns></returns>
        Task<PagedResult<NewsDTO>> GetNewsAsync(PagingParameters pagingparameters);
        /// <summary>
        /// Get All News Today (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingparameters"></param>
        /// <returns></returns>
        Task<PagedResult<NewsDTO>> GetTodayNewsAsync(PagingParameters pagingparameters);
    }
}
