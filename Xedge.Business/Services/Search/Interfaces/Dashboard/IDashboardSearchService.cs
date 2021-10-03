﻿using Xedge.Infrastructure.DashboardViewModels.Orders;
using Xedge.Infrastructure.DashboardViewModels.Products;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Search.Interfaces.Dashboard
{
    public interface IDashboardSearchService
    {
        /// <summary>
        /// Search in Products Using Name or Serial Number (Asynchronous & Paging)
        /// </summary>
        /// <param name="searchTerms"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductViewModel>> SearchProductsAsync(string searchTerms, PagingParameters pagingParameters);
        /// <summary>
        /// Search in Orders Using Order Id (Asynchronous & Paging)
        /// </summary>
        /// <param name="searchTerms"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingOrderViewModel>> SearchOrdersAsync(int id, PagingParameters pagingParameters);
    }
}
