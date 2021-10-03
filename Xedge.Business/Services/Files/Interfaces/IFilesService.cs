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
    }
}
