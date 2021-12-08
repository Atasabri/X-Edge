using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Infrastructure.DashboardViewModels.Files_Category.Files;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Business.Services.Files.Interfaces.Dashboard
{
    public interface IDashboardFilesCategoryService
    {
        /// <summary>
        /// Adding New File Category Asynchronous
        /// </summary>
        /// <param name="addFileCategoryViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateFileCategoryAsync(AddFileCategoryViewModel addFileCategoryViewModel);
        /// <summary>
        /// Edit File Category Asynchronous
        /// </summary>
        /// <param name="editFileCategoryViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditFileCategoryAsync(EditFileCategoryViewModel editFileCategoryViewModel);
        /// <summary>
        /// Delete File Category Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteFileCategoryAsync(int id);
        /// <summary>
        /// Get Files Categories (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<FileCategoryViewModel>> GetDashboardFilesCategoriesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get All Files Categories
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FileCategoryViewModel>> GetAllDashboardFilesCategoriesAsync();
        /// <summary>
        /// Get File Category Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<FileCategoryViewModel> GetFileCategoryDetailsAsync(int Id);
    }
}
