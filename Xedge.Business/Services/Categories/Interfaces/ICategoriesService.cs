using Xedge.Infrastructure.DTOs.Categories;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Categories.Interfaces
{
    public interface ICategoriesService
    {
        /// <summary>
        /// Get Categories List (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<CategoryDTO>> GetCategoriesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Categories List Include Sub Categories(Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<CategoryIncludeSubCategoriesDTO>> GetCategoriesIncludeSubCategoriesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Sub Categories List (Asynchronous & Paging) Using Category Id
        /// </summary>
        /// <param name="catId"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<SubCategoryDTO>> GetSubCategoriesAsync(int catId, PagingParameters pagingParameters);
    }
}
