using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Infrastructure.DashboardViewModels.Files;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Business.Services.Files.Interfaces.Dashboard
{
    public interface IDashboardFilesService
    {
        /// <summary>
        /// Adding New File Asynchronous
        /// </summary>
        /// <param name="addVideoViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateFileAsync(AddFileViewModel addVideoViewModel);
        /// <summary>
        /// Edit File Asynchronous
        /// </summary>
        /// <param name="editVideoViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditFileAsync(EditFileViewModel editVideoViewModel);
        /// <summary>
        /// Delete File Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteFileAsync(int id);
        /// <summary>
        /// Get Files (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<FileViewModel>> GetDashboardFilesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get File Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<FileViewModel> GetFileDetailsAsync(int Id);
    }
}
