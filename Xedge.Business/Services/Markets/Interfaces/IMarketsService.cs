using Xedge.Infrastructure.DTOs.Markets;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Markets.Interfaces
{
    public interface IMarketsService
    {
        /// <summary>
        /// Get Markets List (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<MarketDTO>> GetMarketsAsync(PagingParameters pagingParameters);
    }
}
