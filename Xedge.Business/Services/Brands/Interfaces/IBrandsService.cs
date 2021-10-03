using Xedge.Infrastructure.DTOs.Brand;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Brands.Interfaces
{
    public interface IBrandsService
    {
        /// <summary>
        /// Get Brands List (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<BrandDTO>> GetBrandsAsync(PagingParameters pagingParameters);
    }
}
