using Xedge.Infrastructure.DTOs.Products;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Search.Interfaces
{
    public interface ISearchService
    {
        /// <summary>
        /// Search In Products Using Search Terms (Asynchronous & Paging)
        /// </summary>
        /// <param name="searchTerms"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> SearchAsync(string searchTerms, PagingParameters pagingParameters);
    }
}
