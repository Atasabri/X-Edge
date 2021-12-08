using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Infrastructure.DTOs.Files;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Business.Services.Files.Interfaces
{
    public interface IFilesService
    {
        /// <summary>
        /// Get All Files (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingparameters"></param>
        /// <returns></returns>
        Task<PagedResult<FileDTO>> GetFilesAsync(PagingParameters pagingparameters);
        /// <summary>
        /// Get Files Using Category Id (Asynchronous & Paging)
        /// </summary>
        /// <param name="catId"></param>
        /// <param name="pagingparameters"></param>
        /// <returns></returns>
        Task<PagedResult<FileDTO>> GetFilesUsingCategoryAsync(int catId, PagingParameters pagingparameters);
        /// <summary>
        /// Get Files Categories (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingparameters"></param>
        /// <returns></returns>
        Task<PagedResult<FileCategoryDTO>> GetFilesCategoriesAsync(PagingParameters pagingparameters);
    }
}
